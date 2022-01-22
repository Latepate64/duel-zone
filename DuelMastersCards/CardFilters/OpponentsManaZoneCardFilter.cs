using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    class OpponentsManaZoneCardFilter : CardFilter
    {
        public OpponentsManaZoneCardFilter()
        {
        }

        public OpponentsManaZoneCardFilter(OpponentsManaZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            var opponent = game.GetOpponent(player);
            return opponent != null && opponent.ManaZone.Cards.Contains(card);
        }

        public override CardFilter Copy()
        {
            return new OpponentsManaZoneCardFilter(this);
        }
    }
}
