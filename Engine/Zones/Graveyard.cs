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

        internal override void Add(Card card, IGame game)
        {
            card.KnownTo = [.. game.Players.Select(x => x.Id)];
            Cards.Add(card);
        }

        public Graveyard Copy()
        {
            return new Graveyard(this);
        }

        internal override List<Card> Remove(Card card, IGame game)
        {
            if (Cards.Remove(card))
            {
                return [card];
            }
            else
            {
                return [];
            }
        }

        public override string ToString()
        {
            return "graveyard";
        }
    }
}