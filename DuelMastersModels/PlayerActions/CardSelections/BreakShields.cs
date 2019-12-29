using DuelMastersModels.Cards;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    internal class BreakShields : MandatoryMultipleCardSelection
    {
        internal Creature ShieldBreakingCreature { get; private set; }

        internal BreakShields(Player player, int amount, ReadOnlyCardCollection cards, Creature shieldBreakingCreature) : base(player, amount, cards)
        {
            ShieldBreakingCreature = shieldBreakingCreature;
        }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
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
                return Perform(duel, new ReadOnlyCardCollection(Cards.ToList().GetRange(0, MinimumSelection)));
            }
        }

        internal override PlayerAction Perform(Duel duel, ReadOnlyCardCollection cards)
        {
            return duel.PutFromShieldZoneToHand(duel.GetOpponent(Player), cards, true);
        }
    }
}
