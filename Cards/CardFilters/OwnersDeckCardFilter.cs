using Engine;
using Engine.Zones;

namespace Cards.CardFilters
{
    class OwnersDeckCardFilter : ZoneCardFilter<Deck>
    {
        public OwnersDeckCardFilter() : base(true)
        {
        }

        public OwnersDeckCardFilter(OwnersDeckCardFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new OwnersDeckCardFilter(this);
        }
    }
}
