using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    public class NoneFilter : CardFilter
    {
        public NoneFilter()
        {
        }

        public NoneFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, System.Guid player)
        {
            return false;
        }

        public override CardFilter Copy()
        {
            return new NoneFilter(this);
        }
    }
}
