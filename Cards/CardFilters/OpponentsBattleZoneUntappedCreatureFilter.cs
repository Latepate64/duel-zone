using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneUntappedCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public OpponentsBattleZoneUntappedCreatureFilter() : base()
        {
        }

        public OpponentsBattleZoneUntappedCreatureFilter(OpponentsBattleZoneUntappedCreatureFilter filter) : base()
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && !card.Tapped;
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneUntappedCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your opponent's untapped creatures";
        }
    }
}
