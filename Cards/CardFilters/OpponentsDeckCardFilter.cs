using Engine;
using Engine.Zones;

namespace Cards.CardFilters
{
    class OpponentsDeckCardFilter : ZoneCardFilter<Deck>
    {
        public OpponentsDeckCardFilter() : base(false)
        {
        }

        public OpponentsDeckCardFilter(OpponentsDeckCardFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new OpponentsDeckCardFilter(this);
        }
    }
}