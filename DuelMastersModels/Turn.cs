using DuelMastersModels.PlayerActions;
using DuelMastersModels.Steps;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    internal class Turn
    {
        #region Properties
        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        internal Player ActivePlayer { get; }

        /// <summary>
        /// The opponent of the active player.
        /// </summary>
        internal Player NonActivePlayer { get; }

        /// <summary>
        /// All the steps in the turn that have been or are processed, in order.
        /// </summary>
        internal ObservableCollection<Step> Steps { get; } = new ObservableCollection<Step>();

        /// <summary>
        /// The step that is currently being processed.
        /// </summary>
        internal Step CurrentStep => Steps.Last();

        /// <summary>
        /// The number of the turn.
        /// </summary>
        internal int Number { get; private set; }
        #endregion Properties

        internal Turn(Player activePlayer, Player nonActivePlayer, int number)
        {
            ActivePlayer = activePlayer;
            NonActivePlayer = nonActivePlayer;
            Number = number;
        }

        #region Methods
        /// <summary>
        /// Starts the turn.
        /// </summary>
        internal PlayerAction Start(Duel duel)
        {
            Steps.Add(new StartOfTurnStep(ActivePlayer));
            return CurrentStep.ProcessTurnBasedActions(duel);
        }

        /// <summary>
        /// Adds a new step in order which becomes the current step.
        /// </summary>
        /// <returns>true if steps are no longer added to the turn as it ends, false otherwise</returns>
        internal bool ChangeStep()
        {
            if (CurrentStep is StartOfTurnStep)
            {
                // 500.6. The player who plays first skips the draw step of their first turn.
                if (Number == 1)
                {
                    Steps.Add(new ChargeStep(ActivePlayer));
                }
                else
                {
                    Steps.Add(new DrawStep(ActivePlayer));
                }
            }
            else if (CurrentStep is DrawStep)
            {
                Steps.Add(new ChargeStep(ActivePlayer));
            }
            else if (CurrentStep is ChargeStep)
            {
                Steps.Add(new MainStep(ActivePlayer));
            }
            else if (CurrentStep is MainStep)
            {
                Steps.Add(new AttackDeclarationStep(ActivePlayer, NonActivePlayer));
            }
            else if (CurrentStep is AttackDeclarationStep attackDeclarationStep)
            {
                if (attackDeclarationStep.AttackingCreature != null)
                {
                    Steps.Add(new BlockDeclarationStep(ActivePlayer, attackDeclarationStep.AttackingCreature));
                }
                // 506.2. If an attacking creature is not specified, the other substeps are skipped.
                else
                {
                    Steps.Add(new EndOfTurnStep(ActivePlayer));
                }
            }
            else if (CurrentStep is BlockDeclarationStep blockDeclarationStep)
            {
                AttackDeclarationStep lastAttackDeclaration = Steps.Where(step => step is AttackDeclarationStep).Cast<AttackDeclarationStep>().Last();
                Steps.Add(new BattleStep(ActivePlayer, lastAttackDeclaration.AttackingCreature, lastAttackDeclaration.AttackedCreature, blockDeclarationStep.BlockingCreature));
            }
            else if (CurrentStep is BattleStep)
            {
                AttackDeclarationStep lastAttackDeclaration = Steps.Where(step => step is AttackDeclarationStep).Cast<AttackDeclarationStep>().Last();
                BlockDeclarationStep lastBlockDeclaration = Steps.Where(step => step is BlockDeclarationStep).Cast<BlockDeclarationStep>().Last();

                // 509.1. If the attacking creature was declared to attack the nonactive player and the attack was not redirected, the attack is considered a direct attack.
                bool directAttack = lastAttackDeclaration.AttackedCreature == null && lastBlockDeclaration.BlockingCreature == null;
                Steps.Add(new DirectAttackStep(ActivePlayer, lastAttackDeclaration.AttackingCreature, directAttack));
            }
            else if (CurrentStep is DirectAttackStep)
            {
                Steps.Add(new EndOfAttackStep(ActivePlayer));
            }
            else if (CurrentStep is EndOfAttackStep)
            {
                Steps.Add(new AttackDeclarationStep(ActivePlayer, NonActivePlayer));
            }
            else if (CurrentStep is EndOfTurnStep)
            {
                return true;
            }
            return false;
        }
        #endregion Methods
    }
}
