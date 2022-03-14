using Engine;
using Engine.Zones;

namespace Cards.CardFilters
{
    class OpponentsShieldZoneCardFilter : ZoneCardFilter<ShieldZone>
    {
        public OpponentsShieldZoneCardFilter() : base(false)
        {
        }

        public OpponentsShieldZoneCardFilter(OpponentsShieldZoneCardFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new OpponentsShieldZoneCardFilter(this);
        }
    }
}
