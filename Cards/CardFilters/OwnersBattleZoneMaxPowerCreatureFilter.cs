using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneMaxPowerCreatureFilter : OwnersBattleZoneCreatureFilter
    {
        public PowerFilter Power { get; }

        public OwnersBattleZoneMaxPowerCreatureFilter(int power)
        {
            Power = new PowerFilter(PowerMode.Max, power);
        }

        public OwnersBattleZoneMaxPowerCreatureFilter(OwnersBattleZoneMaxPowerCreatureFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && Power.Applies(card);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneMaxPowerCreatureFilter(this);
        }

        public override string ToString()
        {
            return base.ToString() + Power;
        }
    }
}
