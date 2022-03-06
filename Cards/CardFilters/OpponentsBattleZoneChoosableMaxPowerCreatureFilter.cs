using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableMaxPowerCreatureFilter : OpponentsBattleZoneChoosableCreatureFilter
    {
        public PowerFilter Power { get; }

        public OpponentsBattleZoneChoosableMaxPowerCreatureFilter(int power)
        {
            Power = new PowerFilter(PowerMode.Max, power);
        }

        public OpponentsBattleZoneChoosableMaxPowerCreatureFilter(OpponentsBattleZoneChoosableMaxPowerCreatureFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && Power.Applies(card);
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(this);
        }

        public override string ToString()
        {
            return base.ToString() + Power;
        }
    }
}
