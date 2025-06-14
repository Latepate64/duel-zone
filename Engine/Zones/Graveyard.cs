using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
    /// </summary>
    public class Graveyard : Zone
    {
        public Graveyard(params Card[] cards) : base(ZoneType.Graveyard, cards) { }

        public Graveyard(Graveyard zone) : base(zone)
        {
        }

        public override void Add(Card card, IGame game)
        {
            card.KnownTo = game.Players.Select(x => x.Id).ToList();
            Cards.Add(card);
        }

        public Graveyard Copy()
        {
            return new Graveyard(this);
        }

        public override List<Card> Remove(Card card, IGame game)
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
            return "graveyard";
        }
    }
}