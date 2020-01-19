﻿using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// When a game begins, each player’s deck becomes their deck.
    /// </summary>
    internal class Deck : Zone<IDeckCard>
    {
        internal override bool Public { get; } = false;
        internal override bool Ordered { get; } = true;

        internal Deck(ReadOnlyCardCollection<IZoneCard> cards)
        {
            foreach (IDeckCard card in cards)
            {
                _cards.Add(card);
            }
        }

        internal override void Add(IZoneCard card, Duel duel)
        {
            _cards.Add(new DeckCard(card));
        }

        internal override void Remove(IDeckCard card, Duel duel)
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
                IDeckCard value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }

        /// <summary>
        /// Removes the top card of the deck and returns it.
        /// </summary>
        internal IZoneCard RemoveAndGetTopCard(Duel duel)
        {
            return GetTopCard(true, duel);
        }

        /// <summary>
        /// Returns the top card of a deck. It is also possible to remove the card from the deck.
        /// </summary>
        private IZoneCard GetTopCard(bool remove, Duel duel)
        {
            if (Cards.Count > 0)
            {
                IDeckCard topCard = Cards[Cards.Count - 1];
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
