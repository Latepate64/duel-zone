using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneMaxPowerCreatureFilter : OwnersBattleZoneCreatureFilter
    {
        public int Power { get; }

        public OwnersBattleZoneMaxPowerCreatureFilter(int power)
        {
            Power = power;
        }

        public OwnersBattleZoneMaxPowerCreatureFilter(OwnersBattleZoneMaxPowerCreatureFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Power.Value <= Power;
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneMaxPowerCreatureFilter(this);
        }
    }
}
