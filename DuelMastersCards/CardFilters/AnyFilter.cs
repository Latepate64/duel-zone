using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    public class AnyFilter : CardFilter
    {
        public AnyFilter()
        {
        }

        public AnyFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Duel duel)
        {
            return true;
        }

        public override CardFilter Copy()
        {
            return new AnyFilter(this);
        }
    }
}
