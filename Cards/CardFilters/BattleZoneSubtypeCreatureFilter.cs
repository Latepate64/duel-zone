using Engine;

namespace Cards.CardFilters
{
    class BattleZoneSubtypeCreatureFilter : BattleZoneCreatureFilter, ISubtypeFilterable
    {
        public BattleZoneSubtypeCreatureFilter(params Common.Subtype[] subtypes)
        {
            SubtypeFilter = new SubtypeFilter(subtypes);
        }

        public BattleZoneSubtypeCreatureFilter(BattleZoneSubtypeCreatureFilter filter) : base()
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
            return new BattleZoneSubtypeCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"each other {SubtypeFilter} in the battle zone";
        }
    }
}