using Engine;
using Engine.Zones;

namespace Cards.CardFilters
{
    class OwnersManaZoneCardFilter : ZoneCardFilter<ManaZone>
    {
        public OwnersManaZoneCardFilter() : base(true)
        {
        }

        public OwnersManaZoneCardFilter(OwnersManaZoneCardFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new OwnersManaZoneCardFilter(this);
        }
    }
}
