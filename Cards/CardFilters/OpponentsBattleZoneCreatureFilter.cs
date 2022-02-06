using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneCreatureFilter : OpponentsBattleZoneCardFilter
    {
        public OpponentsBattleZoneCreatureFilter()
        {
        }

        public OpponentsBattleZoneCreatureFilter(OpponentsBattleZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.CardType == Common.CardType.Creature;
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"of your opponent's creatures";
        }
    }
}
