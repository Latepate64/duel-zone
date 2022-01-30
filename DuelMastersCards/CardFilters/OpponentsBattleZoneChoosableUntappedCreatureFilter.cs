using DuelMastersModels;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableUntappedCreatureFilter : OpponentsBattleZoneChoosableCreatureFilter
    {
        public OpponentsBattleZoneChoosableUntappedCreatureFilter()
        {
        }

        public OpponentsBattleZoneChoosableUntappedCreatureFilter(OpponentsBattleZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && !card.Tapped;
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableUntappedCreatureFilter(this);
        }
    }
}
