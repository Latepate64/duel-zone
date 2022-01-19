using DuelMastersModels;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    public class SubtypeFilter : CardFilter
    {
        public Subtype Subtype { get; private set; }

        public SubtypeFilter(Subtype subtype)
        {
            Subtype = subtype;
        }

        public SubtypeFilter(SubtypeFilter filter) : base(filter)
        {
            Subtype = filter.Subtype;
        }

        public override bool Applies(Card card, Game game)
        {
            return card.Subtypes.Contains(Subtype);
        }

        public override CardFilter Copy()
        {
            return new SubtypeFilter(this);
        }
    }
}
