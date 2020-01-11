using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// When a game begins, each player’s deck becomes their deck.
    /// </summary>
    public class Deck : Zone
    {
        internal override bool Public { get; } = false;
        internal override bool Ordered { get; } = true;

        internal Deck(ReadOnlyCardCollection cards)
        {
            foreach (Card card in cards)
            {
                _cards.Add(card);
            }
        }

        internal override void Add(Card card, Duel duel)
        {
            _cards.Add(card);
        }

        internal override void Remove(Card card, Duel duel)
        {
            _cards.Remove(card);
        }

        /// <summary>
        /// Shuffles the deck.
        /// </summary>
        internal void Shuffle()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }

        /// <summary>
        /// Removes the top card of the deck and returns it.
        /// </summary>
        internal Card RemoveAndGetTopCard(Duel duel)
        {
            return GetTopCard(true, duel);
        }

        /// <summary>
        /// Returns the top card of a deck. It is also possible to remove the card from the deck.
        /// </summary>
        private Card GetTopCard(bool remove, Duel duel)
        {
            if (Cards.Count > 0)
            {
                Card topCard = Cards[Cards.Count - 1];
                if (remove)
                {
                    Remove(topCard, duel);
                }
                return topCard;
            }
            else
            {
                throw new InvalidOperationException(nameof(Cards.Count));
            }
        }
    }
}
