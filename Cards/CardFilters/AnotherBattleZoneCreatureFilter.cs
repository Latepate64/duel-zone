using Engine;

namespace Cards.CardFilters
{
    class AnotherBattleZoneCreatureFilter : BattleZoneCreatureFilter, ITargetFilterable
    {
        public AnotherBattleZoneCreatureFilter()
        {
            TargetFilter = new TargetFilter();
        }

        public AnotherBattleZoneCreatureFilter(AnotherBattleZoneCreatureFilter filter)
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
            return new AnotherBattleZoneCreatureFilter(this);
        }

        public override string ToString()
        {
            return "another creature";
        }
    }
}
