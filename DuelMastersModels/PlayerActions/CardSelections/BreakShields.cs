using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class BreakShields : MandatoryMultipleCardSelection
    {
        public Creature ShieldBreakingCreature { get; private set; }

        public BreakShields(Player player, int amount, Collection<Card> cards, Creature shieldBreakingCreature) : base(player, amount, cards)
        {
            ShieldBreakingCreature = shieldBreakingCreature;
        }

        public override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            if (duel.GetOpponent(Player).ShieldZone.Cards.Any(c => c.KnownToOpponent || c.KnownToOwner))
            {
                if (Cards.Count <= MaximumSelection)
                {
                    duel.CurrentTurn.CurrentStep.PlayerActions.Add(this);
                    return Perform(duel, Cards);
                }
                else
                {
                    return this;
                }
            }
            else
            {
                duel.CurrentTurn.CurrentStep.PlayerActions.Add(this);
                return Perform(duel, new Collection<Card>(Cards.ToList().GetRange(0, MinimumSelection)));
            }
        }

        public override PlayerAction Perform(Duel duel, Collection<Card> cards)
        {
            return duel.PutFromShieldZoneToHand(duel.GetOpponent(Player), cards, true);
        }
    }
}
