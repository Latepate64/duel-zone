using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
    /// </summary>
    public class Graveyard : Zone
    {
        public Graveyard() : base() { }

        public Graveyard(Zone zone) : base(zone)
        {
        }

        public override void Add(ICard card, IGame game)
        {
            card.KnownTo = game.Players.Select(x => x.Id).ToList();
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
            return "graveyard";
        }
    }
}