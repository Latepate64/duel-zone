using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableMaxPowerCreatureFilter : OpponentsBattleZoneChoosableCreatureFilter, IPowerFilterable
    {
        public OpponentsBattleZoneChoosableMaxPowerCreatureFilter(int power)
        {
            PowerFilter = new PowerFilter(CompareMode.Max, power);
        }

        public OpponentsBattleZoneChoosableMaxPowerCreatureFilter(OpponentsBattleZoneChoosableMaxPowerCreatureFilter filter) : base()
        {
            PowerFilter = filter.PowerFilter;
        }

        public PowerFilter PowerFilter { get; set; }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && PowerFilter.Applies(card);
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"opponent's creatures {PowerFilter}";
        }
    }
}
