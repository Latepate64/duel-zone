using Engine;
using Engine.Zones;

namespace Cards.CardFilters
{
    class OpponentsHandCardFilter : ZoneCardFilter<Hand>
    {
        public OpponentsHandCardFilter() : base(false)
        {
        }

        public OpponentsHandCardFilter(OpponentsHandCardFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new OpponentsHandCardFilter(this);
        }
    }
}
