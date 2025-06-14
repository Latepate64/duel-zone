using System.Collections.Generic;

namespace Engine.Zones
{
    /// <summary>
    /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
    /// </summary>
    public class ShieldZone : Zone
    {
        public ShieldZone(params Card[] cards) : base(ZoneType.ShieldZone, cards) { }

        public ShieldZone(ShieldZone zone) : base(zone)
        {
        }

        internal override void Add(Card card, IGame game)
        {
            Cards.Add(card);
        }

        public ShieldZone Copy()
        {
            return new ShieldZone(this);
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
            return "shield zone";
        }
    }
}