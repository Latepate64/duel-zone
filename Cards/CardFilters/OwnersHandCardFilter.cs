using Engine;
using Engine.Zones;

namespace Cards.CardFilters
{
    class OwnersHandCardFilter : ZoneCardFilter<Hand>
    {
        public OwnersHandCardFilter() : base(true)
        {
        }

        public OwnersHandCardFilter(OwnersHandCardFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new OwnersHandCardFilter(this);
        }
    }
}
