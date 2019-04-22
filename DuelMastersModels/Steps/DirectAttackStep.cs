using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public class DirectAttackStep : Step
    {
        public Creature AttackingCreature { get; private set; }

        public DirectAttackStep(Player activePlayer, Creature attackingCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            if (AttackingCreature == null)
            {
                throw new System.InvalidOperationException();
            }
            var opponent = duel.GetOpponent(ActivePlayer);
            if (opponent.ShieldZone.Cards.Count > 0)
            {
                PutFromShieldZoneToHand(opponent, opponent.ShieldZone.Cards.Last());
            }
            else
            {
                duel.End(ActivePlayer);
            }
            return null;
        }

        private static void PutFromShieldZoneToHand(Player player, Card card)
        {
            player.ShieldZone.Remove(card);
            player.Hand.Add(card);
        }
    }
}
