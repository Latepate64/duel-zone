using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    public class AttackDeclarationStep : Step
    {
        public Creature AttackingCreature { get; set; }
        public Creature AttackedCreature { get; set; }
        public Player NonactivePlayer { get; private set; }

        public AttackDeclarationStep(Player activePlayer, Player nonactivePlayer) : base(activePlayer)
        {
            NonactivePlayer = nonactivePlayer;
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            return null;
        }

        public override PlayerAction ProcessTurnBasedActions(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            if (ActivePlayer.BattleZone.CreaturesThatCanAttack.Count > 0)
            {
                return new DeclareAttack(ActivePlayer, ActivePlayer.BattleZone.CreaturesThatCanAttack);
            }
            else
            {
                return null;
            }
        }
    }
}
