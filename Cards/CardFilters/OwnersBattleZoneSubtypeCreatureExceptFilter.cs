using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneSubtypeCreatureExceptFilter : OwnersBattleZoneCreatureExceptFilter, ISubtypeFilterable
    {
        public OwnersBattleZoneSubtypeCreatureExceptFilter(params Common.Subtype[] subtypes)
        {
            SubtypeFilter = new SubtypeFilter(subtypes);
        }

        public OwnersBattleZoneSubtypeCreatureExceptFilter(OwnersBattleZoneSubtypeCreatureExceptFilter filter) : base()
        {
            SubtypeFilter = filter.SubtypeFilter;
        }

        public SubtypeFilter SubtypeFilter { get; }

        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return base.Applies(card, game, player) && SubtypeFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneSubtypeCreatureExceptFilter(this);
        }

        public override string ToString()
        {
            return $"each of your other {SubtypeFilter}s in the battle zone";
        }
    }
}