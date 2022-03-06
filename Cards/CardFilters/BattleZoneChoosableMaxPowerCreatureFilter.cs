using Engine;

namespace Cards.CardFilters
{
    class BattleZoneChoosableMaxPowerCreatureFilter : BattleZoneChoosableCreatureFilter
    {
        public PowerFilter Power { get; }

        public BattleZoneChoosableMaxPowerCreatureFilter(int power)
        {
            Power = new PowerFilter(PowerMode.Max, power);
        }

        public BattleZoneChoosableMaxPowerCreatureFilter(BattleZoneChoosableMaxPowerCreatureFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override CardFilter Copy()
        {
            return new BattleZoneChoosableMaxPowerCreatureFilter(this);
        }

        public override string ToString()
        {
            return base.ToString() + Power;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && Power.Applies(card);
        }
    }
}
