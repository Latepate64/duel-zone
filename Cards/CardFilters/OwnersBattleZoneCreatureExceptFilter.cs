using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCreatureExceptFilter : OwnersBattleZoneCreatureFilter, ITargetFilterable
    {
        public OwnersBattleZoneCreatureExceptFilter() : base()
        {
            TargetFilter = new TargetFilter();
        }

        public OwnersBattleZoneCreatureExceptFilter(OwnersBattleZoneCreatureExceptFilter filter) : base()
        {
            TargetFilter = filter.TargetFilter;
        }

        public TargetFilter TargetFilter { get; set; }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Id != TargetFilter.Target;
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneCreatureExceptFilter(this);
        }

        public override string ToString()
        {
            return $"your other creatures";
        }
    }
}
