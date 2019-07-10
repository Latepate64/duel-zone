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
        public bool TargetOfAttackDeclared { get; set; }

        public AttackDeclarationStep(Player activePlayer, Player nonactivePlayer) : base(activePlayer)
        {
            NonactivePlayer = nonactivePlayer;
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            if (AttackingCreature != null && !TargetOfAttackDeclared)
            {
                //TODO: If attacked creature is not null, check that it can be attacked.
                return new DeclareTargetOfAttack(ActivePlayer, NonactivePlayer.BattleZone.TappedCreatures);
            }
            else
            {
                return null;
            }
        }

        public override PlayerAction ProcessTurnBasedActions(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            if (ActivePlayer.BattleZone.CreaturesThatCanAttack.Count > 0)
            {
                //return new DeclareAttack(ActivePlayer, ActivePlayer.BattleZone.CreaturesThatCanAttack);
                return new DeclareAttacker(ActivePlayer, ActivePlayer.BattleZone.CreaturesThatCanAttack);
            }
            else
            {
                return null;
            }
        }
    }
}
