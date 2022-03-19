using Engine;

namespace Cards.CardFilters
{
    class OwnersManaZoneCreatureFilter : OwnersManaZoneCardFilter
    {
        public OwnersManaZoneCreatureFilter()
        {
        }

        public OwnersManaZoneCreatureFilter(OwnersManaZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return base.Applies(card, game, player) && new CreatureFilter().Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersManaZoneCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()} creature";
        }
    }
}