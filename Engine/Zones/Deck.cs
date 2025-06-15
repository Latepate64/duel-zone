using System.Collections.Generic;
using System.Linq;

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

        internal override void Add(Card card)
        {
            Cards.Add(card);
        }

        internal override List<Card> Remove(Card card, IGame game)
        {
            if (!Cards.Remove(card))
            {
                return [];
            }
            else
            {
                return [card];
            }
        }

        public IEnumerable<Card> GetTopCards(int amount) => Cards.TakeLast(amount);

        public void PutOnBottom(Card[] cards)
        {
            Cards.InsertRange(0, cards);
        }

        public Deck Copy()
        {
            return new Deck(this);
        }

        public void Shuffle(IRandomizer randomizer)
        {
            randomizer.Shuffle(Cards);
        }

        public Card TopCard => GetTopCards(1).SingleOrDefault();
    }
}
