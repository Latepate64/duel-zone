using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    public class BattleStep : Step
    {
        public Creature AttackingCreature { get; private set; }
        public Creature DefendingCreature { get; private set; }

        public BattleStep(Player activePlayer, Creature attackingCreature, Creature defendingCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
            DefendingCreature = defendingCreature;
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            if (AttackingCreature != null && DefendingCreature != null)
            {
                Duel.Battle(AttackingCreature, DefendingCreature, ActivePlayer, duel.CurrentTurn.NonActivePlayer);
                return null;
            }
            else
            {
                throw new System.InvalidOperationException();
            }
        }

        
    }
}
