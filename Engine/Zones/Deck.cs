using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Engine.Zones
{
    /// <summary>
    /// When a game begins, each player’s deck becomes their deck.
    /// </summary>
    public class Deck : Zone
    {
        public Deck(params Card[] cards) : base(ZoneType.Deck, cards)
        {
        }

        public Deck(Deck zone) : base(zone)
        {
        }

        public IEnumerable<Card> GetTopCards(int amount) => Cards.TakeLast(amount);

        public Deck Copy()
        {
            return new Deck(this);
        }

        public Card TopCard => GetTopCards(1).SingleOrDefault();
    }
}
