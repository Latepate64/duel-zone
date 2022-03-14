using Engine;
using Engine.Zones;

namespace Cards.CardFilters
{
    class OwnersShieldZoneCardFilter : ZoneCardFilter<ShieldZone>
    {
        public OwnersShieldZoneCardFilter() : base(true)
        {
        }

        public OwnersShieldZoneCardFilter(OwnersShieldZoneCardFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new OwnersShieldZoneCardFilter(this);
        }
    }
}
