using Interfaces;

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

        public Graveyard Copy()
        {
            return new Graveyard(this);
        }
    }
}