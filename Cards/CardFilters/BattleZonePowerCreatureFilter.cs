using Engine;

namespace Cards.CardFilters
{
    class BattleZonePowerCreatureFilter : BattleZoneCreatureFilter
    {
        public PowerFilter Power { get; }

        public BattleZonePowerCreatureFilter(PowerFilter power)
        {
            Power = power;
        }

        public BattleZonePowerCreatureFilter(BattleZonePowerCreatureFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && Power.Applies(card);
        }

        public override CardFilter Copy()
        {
            return new BattleZonePowerCreatureFilter(this);
        }

        public override string ToString()
        {
            return base.ToString() + Power;
        }
    }
}
