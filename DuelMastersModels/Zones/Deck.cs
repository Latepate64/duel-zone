using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// When a game begins, each player’s deck becomes their deck.
    /// </summary>
    public class Deck : Zone
    {
        public Deck(IEnumerable<Card> cards) : base(cards) { }

        public override void Add(Card card, Duel duel)
        {
            Cards.Add(card);
        }

        public override void Remove(Card card, Duel duel)
        {
            if (!Cards.Remove(card))
            {
                throw new NotSupportedException(card.ToString());
            }
            if (!Cards.Any())
            {
                var player = duel.GetPlayer(card.Owner);
                duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(new DeckoutEvent(player.Copy()));
                duel.Lose(player);
            }
        }

        /// <summary>
        /// Shuffles the deck.
        /// </summary>
        public void Shuffle()
        {
            foreach (var card in Cards)
            {
                card.RevealedTo = new List<Guid>();
            }
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
        public Card RemoveAndGetTopCard(Duel duel)
        {
            return GetTopCard(true, duel);
        }

        /// <summary>
        /// Returns the top card of a deck. It is also possible to remove the card from the deck.
        /// </summary>
        private Card GetTopCard(bool remove, Duel duel)
        {
            if (Cards.Any())
            {
                Card topCard = Cards.Last();
                if (remove)
                {
                    Remove(topCard, duel);
                }
                return topCard;
            }
            else
            {
                return null;
            }
        }

        public override Zone Copy()
        {
            return new Deck(Cards.Select(x => x.Copy()));
        }

        public override string ToString()
        {
            return "deck";
        }
    }
}
