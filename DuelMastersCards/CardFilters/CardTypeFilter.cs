using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    public class CardTypeFilter : CardFilter
    {
        public CardType CardType { get; }

        public CardTypeFilter(CardType cardType)
        {
            CardType = cardType;
        }

        public CardTypeFilter(CardTypeFilter filter) : base(filter)
        {
            CardType = filter.CardType;
        }

        public override bool Applies(Card card, Game game, System.Guid player)
        {
            return card.CardType == CardType;
        }

        public override CardFilter Copy()
        {
            return new CardTypeFilter(this);
        }
    }
}
