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

        public override void Add(Card card, IGame game)
        {
            Cards.Add(card);
        }

        public override List<Card> Remove(Card card, IGame game)
        {
            if (!Cards.Remove(card))
            {
                return new List<Card>();
            }
            else
            {
                return new List<Card> { card };
            }
        }

        public override string ToString()
        {
            return "deck";
        }

        public void Setup(IEnumerable<Card> cards, IPlayer owner)
        {
            cards.ToList().ForEach(x => x.Owner = owner);
            Cards.AddRange(cards);
        }

        public IEnumerable<Card> GetTopCards(int amount)
        {
            return Cards.TakeLast(amount);
        }

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
