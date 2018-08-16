using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CreatureSelections;

namespace DuelMastersModels.Steps
{
    public class AttackDeclarationStep : Step
    {
        public Creature AttackingCreature { get; set; }
        public Creature AttackedCreature { get; set; }
        public Player NonactivePlayer { get; private set; }

        private bool _mustBeEnded = false;

        public AttackDeclarationStep(Player activePlayer, Player nonactivePlayer) : base(activePlayer, "Attack declaration")
        {
            NonactivePlayer = nonactivePlayer;
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            if (!_mustBeEnded && AttackingCreature != null)
            {
                _mustBeEnded = true;
                return new DeclareTargetOfAttack(ActivePlayer, NonactivePlayer.BattleZone.TappedCreatures);
            }
            else
            {
                return null;
            }
        }

        public override PlayerAction ProcessTurnBasedActions(Duel duel)
        {
            return new DeclareAttacker(ActivePlayer, ActivePlayer.BattleZone.CreaturesThatCanAttack);
        }
    }
}
