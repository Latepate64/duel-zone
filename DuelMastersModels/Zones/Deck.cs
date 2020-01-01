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

        internal Deck(Player owner) : base(owner) { }

        internal override void Add(Card card, Duel duel)
        {
            Cards.Add(card);
        }

        internal override void Remove(Card card, Duel duel)
        {
            Cards.Remove(card);
        }

        /// <summary>
        /// Shuffles the deck.
        /// </summary>
        internal void Shuffle()
        {
            Cards.Shuffle();
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
                throw new ArgumentException("Deck is out of cards.");
            }
        }
    }
}
