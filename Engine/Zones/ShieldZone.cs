using System.Collections.Generic;

namespace Engine.Zones
{
    /// <summary>
    /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
    /// </summary>
    public class ShieldZone : Zone
    {
        public ShieldZone() : base(ZoneType.ShieldZone) { }

        public ShieldZone(ShieldZone zone) : base(zone)
        {
        }

        public override void Add(ICard card, IGame game)
        {
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
            return "shield zone";
        }
    }
}