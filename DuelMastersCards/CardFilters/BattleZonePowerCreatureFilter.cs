using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    class BattleZonePowerCreatureFilter : BattleZoneCreatureFilter
    {
        public int Power { get; }

        public BattleZonePowerCreatureFilter(int power)
        {
            Power = power;
        }

        public BattleZonePowerCreatureFilter(BattleZonePowerCreatureFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Power.Value == Power;
        }

        public override CardFilter Copy()
        {
            return new BattleZonePowerCreatureFilter(this);
        }
    }
}
