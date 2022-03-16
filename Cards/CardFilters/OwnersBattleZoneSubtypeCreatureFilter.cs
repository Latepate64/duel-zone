using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneSubtypeCreatureFilter : OwnersBattleZoneCreatureExceptFilter, ISubtypeFilterable
    {
        public OwnersBattleZoneSubtypeCreatureFilter(params Common.Subtype[] subtypes)
        {
            SubtypeFilter = new SubtypeFilter(subtypes);
        }

        public OwnersBattleZoneSubtypeCreatureFilter(OwnersBattleZoneSubtypeCreatureFilter filter) : base(filter)
        {
            SubtypeFilter = filter.SubtypeFilter;
        }

        public SubtypeFilter SubtypeFilter { get; }

        public override bool Applies(Card card, Game game, Player player)
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