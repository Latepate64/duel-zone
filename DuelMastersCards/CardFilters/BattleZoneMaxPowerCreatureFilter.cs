using DuelMastersModels;

namespace Cards.CardFilters
{
    class BattleZoneMaxPowerCreatureFilter : BattleZoneCreatureFilter
    {
        public int Power { get; }

        public BattleZoneMaxPowerCreatureFilter(int power)
        {
            Power = power;
        }

        public BattleZoneMaxPowerCreatureFilter(BattleZoneMaxPowerCreatureFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Power.Value <= Power;
        }

        public override CardFilter Copy()
        {
            return new BattleZoneMaxPowerCreatureFilter(this);
        }
    }
}
