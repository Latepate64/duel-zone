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

        public override bool Remove(Card card, Game game)
        {
            return Cards.Remove(card);
        }

        public override string ToString()
        {
            return "hand";
        }
    }
}