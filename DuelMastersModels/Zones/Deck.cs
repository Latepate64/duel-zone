using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.Zones
{
    public class Deck : Zone
    {
        public override bool Public { get; } = false;
        public override bool Ordered { get; } = true;

        public Deck(Player owner) : base(owner) { }

        public override void Add(Card card)
        {
            Cards.Add(card);
        }

        public override void Remove(Card card)
        {
            Cards.Remove(card);
        }

        /// <summary>
        /// Shuffles the deck.
        /// </summary>
        public void Shuffle()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }

        /// <summary>
        /// Removes the top card of the deck and returns it.
        /// </summary>
        public Card RemoveAndGetTopCard()
        {
            return GetTopCard(true);
        }

        /// <summary>
        /// Returns the top card of a deck. It is also possible to remove the card from the deck.
        /// </summary>
        private Card GetTopCard(bool remove)
        {
            if (Cards.Count > 0)
            {
                Card topCard = Cards[Cards.Count - 1];
                if (remove)
                {
                    Remove(topCard);
                }
                return topCard;
            }
            else
            {
                throw new ArgumentException("Deck is out of cards.");
            }
        }
    }
}
