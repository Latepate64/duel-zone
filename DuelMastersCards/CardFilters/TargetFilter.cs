using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    public class TargetFilter : CardFilter
    {
        public TargetFilter()
        {
        }

        public TargetFilter(TargetFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new TargetFilter(this);
        }

        public override bool Applies(Card card, Duel duel)
        {
            return Target == card.Id;
        }
    }
}
