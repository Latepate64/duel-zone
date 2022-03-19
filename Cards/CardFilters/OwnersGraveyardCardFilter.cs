using Engine;
using Engine.Zones;

namespace Cards.CardFilters
{
    class OwnersGraveyardCardFilter : ZoneCardFilter<Graveyard>
    {
        public OwnersGraveyardCardFilter(params Common.Civilization[] civilizations) : base(true) //TODO: civilizations
        {
        }

        public OwnersGraveyardCardFilter(OwnersGraveyardCardFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new OwnersGraveyardCardFilter(this);
        }
    }
}
