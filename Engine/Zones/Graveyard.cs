using System.Collections.Generic;

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

        internal override void Add(Card card)
        {
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
    }
}