using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// When a game begins, each player’s deck becomes their deck.
    /// </summary>
    public class Deck : Zone, IDeck
    {
        public Deck() : base(ZoneType.Deck) { }

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

        public void Shuffle()
        {
            // 701.16c If cards in a player’s library are shuffled or otherwise reordered, any revealed cards that are reordered stop being revealed and become new objects.
            // TODO: Become new objects
            foreach (var card in Cards)
            {
                card.KnownTo = new List<Guid>();
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }

        public override string ToString()
        {
            return "deck";
        }

        public void Setup(IEnumerable<ICard> cards, Guid owner)
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
    }
}
