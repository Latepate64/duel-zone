using Engine;

namespace Cards.CardFilters
{
    class OwnersManaZoneMinCostCreatureFilter : OwnersManaZoneCreatureFilter, IManaCostFilterable
    {
        public OwnersManaZoneMinCostCreatureFilter(int cost)
        {
            ManaCostFilter = new ManaCostFilter(CompareMode.Min, cost);
        }

        public OwnersManaZoneMinCostCreatureFilter(OwnersManaZoneMinCostCreatureFilter filter) : base(filter)
        {
            ManaCostFilter = filter.ManaCostFilter;
        }

        public ManaCostFilter ManaCostFilter { get; }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && ManaCostFilter.Applies(card);
        }

        public override CardFilter Copy()
        {
            return new OwnersManaZoneMinCostCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"a creature that costs {ManaCostFilter} from your mana zone";
        }
    }
}