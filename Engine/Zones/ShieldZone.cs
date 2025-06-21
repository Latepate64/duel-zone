using Interfaces;

namespace Engine.Zones
{

    /// <summary>
    /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
    /// </summary>
    public class ShieldZone : Zone, IShieldZone
    {
        public ShieldZone(params ICard[] cards) : base(ZoneType.ShieldZone, cards) { }

        public ShieldZone(ShieldZone zone) : base(zone)
        {
        }

        public ShieldZone Copy()
        {
            return new ShieldZone(this);
        }
    }
}