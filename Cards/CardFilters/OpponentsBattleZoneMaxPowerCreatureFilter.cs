using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneMaxPowerCreatureFilter : OpponentsBattleZoneCreatureFilter, IPowerFilterable
    {
        public OpponentsBattleZoneMaxPowerCreatureFilter(int power)
        {
            PowerFilter = new PowerFilter(CompareMode.Max, power);
        }

        public OpponentsBattleZoneMaxPowerCreatureFilter(OpponentsBattleZoneMaxPowerCreatureFilter filter) : base(filter)
        {
            PowerFilter = filter.PowerFilter;
        }

        public PowerFilter PowerFilter { get; set; }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && PowerFilter.Applies(card);
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneMaxPowerCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your opponent's creatures {PowerFilter}";
        }
    }
}