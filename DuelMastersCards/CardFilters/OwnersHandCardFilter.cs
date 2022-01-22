using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    class OwnersHandCardFilter : CardFilter
    {
        public OwnersHandCardFilter()
        {
        }

        public OwnersHandCardFilter(OwnersHandCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return player != null && player.Hand.Cards.Contains(card);
        }

        public override CardFilter Copy()
        {
            return new OwnersHandCardFilter(this);
        }
    }
}
