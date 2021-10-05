using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    public class SourceFilter : CardFilter
    {
        public SourceFilter()
        {
        }

        public SourceFilter(SourceFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new SourceFilter(this);
        }

        public override bool Applies(Card card, Duel duel)
        {
            return Source == card.Id;
        }
    }
}
