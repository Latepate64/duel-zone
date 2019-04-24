using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using System;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public class DirectAttackStep : Step
    {
        public Creature AttackingCreature { get; private set; }
        public bool DirectAttack { get; private set; }

        public DirectAttackStep(Player activePlayer, Creature attackingCreature, bool directAttack) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
            DirectAttack = directAttack;
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            if (DirectAttack)
            {
                if (AttackingCreature == null)
                {
                    throw new InvalidOperationException();
                }
                Player opponent = duel.GetOpponent(ActivePlayer);
                if (opponent.ShieldZone.Cards.Count > 0)
                {
                    PutFromShieldZoneToHand(opponent, opponent.ShieldZone.Cards.Last());
                }
                else
                {
                    // 509.1. If the nonactive player has no shields left, that player loses the game. This is a state-based action.
                    duel.End(ActivePlayer);
                }
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
