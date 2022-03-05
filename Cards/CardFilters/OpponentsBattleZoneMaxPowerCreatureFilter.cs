using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneMaxPowerCreatureFilter : OpponentsBattleZoneCardFilter
    {
        public int Power { get; set; }

        public OpponentsBattleZoneMaxPowerCreatureFilter(int power)
        {
            Power = power;
        }

        public OpponentsBattleZoneMaxPowerCreatureFilter(OpponentsBattleZoneMaxPowerCreatureFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneMaxPowerCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your opponent's {ToStringBase()}s that have power ${Power} or less";
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Power <= Power;
        }
    }
}