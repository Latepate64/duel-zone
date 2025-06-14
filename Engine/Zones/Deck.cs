using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// When a game begins, each player’s deck becomes their deck.
    /// </summary>
    public class Deck : Zone, IDeck
    {
        public Deck(params ICard[] cards) : base(ZoneType.Deck, cards)
        {
        }

        public Deck(IDeck zone) : base(zone)
        {
        }

        public override void Add(ICard card, IGame game)
        {
            Cards.Add(card);
        }

        public override List<ICard> Remove(ICard card, IGame game)
        {
            if (!Cards.Remove(card))
            {
                return new List<ICard>();
            }
            else
            {
                return new List<ICard> { card };
            }
        }

        public override string ToString()
        {
            return "deck";
        }

        public void Setup(IEnumerable<ICard> cards, IPlayer owner)
        {
            cards.ToList().ForEach(x => x.Owner = owner);
            Cards.AddRange(cards);
        }

        public IEnumerable<ICard> GetTopCards(int amount)
        {
            return Cards.TakeLast(amount);
        }

        public void PutOnBottom(ICard[] cards)
        {
            Cards.InsertRange(0, cards);
        }

        public IDeck Copy()
        {
            return new Deck(this);
        }

        public void Shuffle(IRandomizer randomizer)
        {
            randomizer.Shuffle(Cards);
        }

        public ICard TopCard => GetTopCards(1).SingleOrDefault();
    }
}
