using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
    /// </summary>
    public class Hand : Zone
    {
        public Hand(IEnumerable<Card> cards) : base(cards) { }

        public override void Add(Card card, Game game)
        {
            var revealedTo = new List<Guid> { card.Owner };
            var opponent = game.GetOpponent(card.Owner);
            if (card.KnownBy.Contains(opponent))
            {
                revealedTo.Add(opponent);
            }
            card.KnownBy = revealedTo;
            Cards.Add(card);
        }

        public override void Remove(Card card, Game game)
        {
            if (!Cards.Remove(card))
            {
                throw new NotSupportedException(card.ToString());
            }
        }

        public override Zone Copy()
        {
            return new Hand(Cards.Select(x => x.Copy()));
        }

        public override string ToString()
        {
            return "hand";
        }
    }
}