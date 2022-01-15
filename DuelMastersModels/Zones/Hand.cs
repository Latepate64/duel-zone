using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
    /// </summary>
    public class Hand : Zone, ICopyable<Hand>
    {
        public Hand(IEnumerable<Card> cards) : base(cards) { }

        public override Choice Add(Card card, Duel duel)
        {
            var revealedTo = new List<Guid> { card.Owner };
            var opponent = duel.GetOpponent(card.Owner);
            if (card.RevealedTo.Contains(opponent))
            {
                revealedTo.Add(opponent);
            }
            card.RevealedTo = revealedTo;
            Cards.Add(card);
            return null;
        }

        public override void Remove(Card card)
        {
            if (!Cards.Remove(card))
            {
                throw new NotSupportedException(card.ToString());
            }
            card.ShieldTriggerPending = false;
        }

        public Hand Copy()
        {
            return new Hand(Cards.Select(x => x.Copy()));
        }

        public override string ToString()
        {
            return "hand";
        }
    }
}