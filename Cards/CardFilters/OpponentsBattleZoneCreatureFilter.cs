using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneCreatureFilter : OpponentsBattleZoneCardFilter
    {
        public OpponentsBattleZoneCreatureFilter() : base()
        {
        }

        public OpponentsBattleZoneCreatureFilter(OpponentsBattleZoneCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && new CreatureFilter().Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your opponent's creatures";
        }
    }
}
