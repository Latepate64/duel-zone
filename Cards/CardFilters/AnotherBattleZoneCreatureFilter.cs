using Engine;

namespace Cards.CardFilters
{
    class AnotherBattleZoneCreatureFilter : BattleZoneCreatureFilter
    {
        public AnotherBattleZoneCreatureFilter()
        {
        }

        public AnotherBattleZoneCreatureFilter(AnotherBattleZoneCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Id != Target;
        }

        public override CardFilter Copy()
        {
            return new AnotherBattleZoneCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"another {ToStringBase()}";
        }
    }
}
