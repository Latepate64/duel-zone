using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
    /// </summary>
    public class Graveyard : Zone
    {
        public Graveyard(IEnumerable<Card> cards) : base(cards) { }

        public override Choice Add(Card card, Duel duel, Zone source)
        {
            card.RevealedTo = duel.Players.Select(x => x.Id).ToList();
            Cards.Add(card);
            return null;
        }

        public override void Remove(Card card)
        {
            if (!Cards.Remove(card))
            {
                throw new System.NotSupportedException(card.ToString());
            }
        }

        public override Zone Copy()
        {
            return new Graveyard(Cards.Select(x => x.Copy()));
        }

        public override string ToString()
        {
            return "graveyard";
        }
    }
}