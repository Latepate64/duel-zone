using System;
using System.Collections.Generic;

namespace Engine.Zones
{
    /// <summary>
    /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
    /// </summary>
    public class Hand : Zone
    {
        public Hand() : base() { }

        public Hand(Zone zone) : base(zone)
        {
        }

        public override void Add(Card card, Game game)
        {
            card.KnownTo = new List<Guid> { card.Owner };
            Cards.Add(card);
        }

        public override List<Card> Remove(Card card, Game game)
        {
            if (Cards.Remove(card))
            {
                return new List<Card> { card };
            }
            else
            {
                return new List<Card>();
            }
        }

        public override string ToString()
        {
            return "hand";
        }
    }
}