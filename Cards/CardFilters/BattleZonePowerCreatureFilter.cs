using Engine;

namespace Cards.CardFilters
{
    class BattleZonePowerCreatureFilter : BattleZoneCreatureFilter, IPowerFilterable
    {
        public BattleZonePowerCreatureFilter(PowerFilter powerFilter)
        {
            PowerFilter = powerFilter;
        }

        public BattleZonePowerCreatureFilter(BattleZonePowerCreatureFilter filter) : base()
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
            return new BattleZonePowerCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"creature {PowerFilter}";
        }
    }
}
