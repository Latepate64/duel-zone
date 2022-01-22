using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    class OpponentsHandCardFilter : CardFilter
    {
        public OpponentsHandCardFilter()
        {
        }

        public OpponentsHandCardFilter(OpponentsHandCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            var opponent = game.GetOpponent(player);
            return opponent != null && opponent.Hand.Cards.Contains(card);
        }

        public override CardFilter Copy()
        {
            return new OpponentsHandCardFilter(this);
        }
    }
}
