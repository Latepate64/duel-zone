using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneMaxPowerCreatureFilter : OwnersBattleZoneCreatureFilter, IPowerFilterable
    {
        public OwnersBattleZoneMaxPowerCreatureFilter(int power)
        {
            PowerFilter = new PowerFilter(CompareMode.Max, power);
        }

        public OwnersBattleZoneMaxPowerCreatureFilter(OwnersBattleZoneMaxPowerCreatureFilter filter) : base()
        {
            PowerFilter = filter.PowerFilter;
        }

        public PowerFilter PowerFilter { get; set; }

        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return base.Applies(card, game, player) && PowerFilter.Applies(card);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneMaxPowerCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your creatures {PowerFilter}";
        }
    }
}
