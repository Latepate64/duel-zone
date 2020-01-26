using DuelMastersModels.Cards;
using DuelMastersModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// When a game begins, each player’s deck becomes their deck.
    /// </summary>
    public class Deck : Zone<IDeckCard>
    {
        internal override bool Public { get; } = false;
        internal override bool Ordered { get; } = true;

        internal Deck(IEnumerable<ICard> cards)
        {
            foreach (ICard card in cards)
            {
                _cards.Add(CardFactory.GenerateDeckCard(card));
            }
        }

        internal override void Add(IDeckCard card, Duel duel)
        {
            _cards.Add(card);
        }

        internal override void Remove(IDeckCard card, Duel duel)
        {
            _ = _cards.Remove(card);
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
                IDeckCard value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }

        /// <summary>
        /// Removes the top card of the deck and returns it.
        /// </summary>
        internal ICard RemoveAndGetTopCard(Duel duel)
        {
            return GetTopCard(true, duel);
        }

        /// <summary>
        /// Returns the top card of a deck. It is also possible to remove the card from the deck.
        /// </summary>
        private ICard GetTopCard(bool remove, Duel duel)
        {
            if (Cards.Any())
            {
                IDeckCard topCard = Cards.Last();
                if (remove)
                {
                    Remove(topCard, duel);
                }
                return topCard;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
