using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneSubtypeCreatureFilter : OwnersBattleZoneCreatureFilter, ISubtypeFilterable
    {
        public OwnersBattleZoneSubtypeCreatureFilter(params Common.Subtype[] subtypes)
        {
            SubtypeFilter = new SubtypeFilter(subtypes);
        }

        public OwnersBattleZoneSubtypeCreatureFilter(OwnersBattleZoneSubtypeCreatureFilter filter) : base()
        {
            SubtypeFilter = filter.SubtypeFilter;
        }

        public SubtypeFilter SubtypeFilter { get; }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && SubtypeFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneSubtypeCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your {SubtypeFilter} in the battle zone";
        }
    }
}