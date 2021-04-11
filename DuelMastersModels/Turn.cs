using DuelMastersModels.Choices;
using DuelMastersModels.Steps;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    public class Turn : ITurn
    {
        #region Properties
        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        public IPlayer ActivePlayer { get; }

        /// <summary>
        /// The opponent of the active player.
        /// </summary>
        public IPlayer NonActivePlayer { get; }

        /// <summary>
        /// All the steps in the turn that have been or are processed, in order.
        /// </summary>
        internal ICollection<IStep> Steps { get; } = new Collection<IStep>();

        /// <summary>
        /// The step that is currently being processed.
        /// </summary>
        public IStep CurrentStep => Steps.Last();

        /// <summary>
        /// The number of the turn.
        /// </summary>
        internal int Number { get; private set; }
        #endregion Properties

        public Turn(IPlayer activePlayer, int number)
        {
            ActivePlayer = activePlayer;
            NonActivePlayer = activePlayer.Opponent;
            Number = number;
        }

        /// <summary>
        /// Adds a new step in order which becomes the current step.
        /// </summary>
        /// <returns>null if turn is over, choice otherwise</returns>
        public IChoice ChangeStep(IDuel duel)
        {
            if (!Steps.Any())
            {
                Steps.Add(new StartOfTurnStep(ActivePlayer));
            }
            else if (CurrentStep is StartOfTurnStep)
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
                Steps.Add(new AttackDeclarationStep(ActivePlayer));
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
                Steps.Add(new AttackDeclarationStep(ActivePlayer));
            }
            else if (CurrentStep is EndOfTurnStep)
            {
                return null;
            }
            return StartStep(duel);
        }

        /// <summary>
        /// Starts a step. Should be called only once per step.
        /// </summary>
        /// <param name="duel"></param>
        /// <returns></returns>
        public IChoice StartStep(IDuel duel)
        {
            // 703.3. Whenever a step or phase begins, if it’s a step or phase that has any turn-based action associated with it, those turn-based actions are automatically dealt with first. This happens before state-based actions are checked, before triggered abilities are put on the stack, and before players receive priority.
            if (CurrentStep is ITurnBasedActionable actionable)
            {
                IChoice choice = actionable.PerformTurnBasedActions(duel);
                if (choice != null)
                {
                    return choice;
                }
            }
            return ProcessStep(duel);
        }

        /// <summary>
        /// Performs state-based actions, checks pending abilities and gives priority to the active player.
        /// </summary>
        /// <returns></returns>
        public IChoice ProcessStep(IDuel duel)
        {
            // TODO: Check state-based actions
            // TODO: Check pending abilities
            if (CurrentStep is IPriorityActionable actionable)
            {
                return actionable.GivePriorityToActivePlayer(duel);
            }
            else
            {
                return ChangeStep(duel);
            }
        }
    }
}
