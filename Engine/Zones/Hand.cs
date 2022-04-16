using System;
using System.Collections.Generic;

namespace Engine.Zones
{
    /// <summary>
    /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
    /// </summary>
    public class Hand : Zone
    {
        public Hand() : base(ZoneType.Hand) { }

        public Hand(Zone zone) : base(zone)
        {
        }

        public override void Add(ICard card, IGame game)
        {
            card.KnownTo = new List<Guid> { card.Owner };
            Cards.Add(card);
        }

        public override List<ICard> Remove(ICard card, IGame game)
        {
            if (Cards.Remove(card))
            {
                return new List<ICard> { card };
            }
            else
            {
                return new List<ICard>();
            }
        }

        public override string ToString()
        {
            return "hand";
        }
    }
}