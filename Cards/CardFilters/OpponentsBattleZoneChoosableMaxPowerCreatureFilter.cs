using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableMaxPowerCreatureFilter : OpponentsBattleZoneChoosableCreatureFilter
    {
        public int Power { get; }

        public OpponentsBattleZoneChoosableMaxPowerCreatureFilter(int power)
        {
            Power = power;
        }

        public OpponentsBattleZoneChoosableMaxPowerCreatureFilter(OpponentsBattleZoneChoosableMaxPowerCreatureFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Power.Value <= Power;
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(this);
        }

        public override string ToString()
        {
            return base.ToString() + $" with power {Power} or less";
        }
    }
}
