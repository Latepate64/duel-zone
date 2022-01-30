using Engine;

namespace Cards.CardFilters
{
    class BattleZoneCardFilter : CardFilter
    {
        public BattleZoneCardFilter()
        {
        }

        public BattleZoneCardFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && game.BattleZone.Cards.Contains(card);
        }

        public override CardFilter Copy()
        {
            return new BattleZoneCardFilter(this);
        }
    }
}
