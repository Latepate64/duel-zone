using Engine;
using Engine.Zones;

namespace Cards.CardFilters
{
    class OpponentsManaZoneCardFilter : ZoneCardFilter<ManaZone>
    {
        public OpponentsManaZoneCardFilter() : base(false)
        {
        }

        public OpponentsManaZoneCardFilter(OpponentsManaZoneCardFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new OpponentsManaZoneCardFilter(this);
        }
    }
}
