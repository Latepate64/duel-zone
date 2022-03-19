using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneMaxCostCreatureFilter : OwnersBattleZoneCreatureFilter, IManaCostFilterable
    {
        public ManaCostFilter ManaCostFilter { get; }

        public OwnersBattleZoneMaxCostCreatureFilter(int cost)
        {
            ManaCostFilter = new ManaCostFilter(CompareMode.Max, cost);
        }

        public OwnersBattleZoneMaxCostCreatureFilter(OwnersBattleZoneMaxCostCreatureFilter filter) : base()
        {
            ManaCostFilter = filter.ManaCostFilter;
        }

        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return base.Applies(card, game, player) && ManaCostFilter.Applies(card);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneMaxCostCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your creatures that costs {ManaCostFilter} or less";
        }
    }
}