using Engine;
using System.Collections.Generic;
using System.Linq;

namespace Cards.CardFilters
{
    sealed class SubtypeFilter : CardFilter
    {
        public List<Common.Subtype> Subtypes { get; } = new List<Common.Subtype>();

        public SubtypeFilter(params Common.Subtype[] subtypes)
        {
            Subtypes.AddRange(subtypes);
        }

        public SubtypeFilter(SubtypeFilter filter) : base()
        {
            Subtypes = filter.Subtypes;
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return card.Subtypes.Intersect(Subtypes).Any();
        }

        public override CardFilter Copy()
        {
            return new SubtypeFilter(this);
        }

        public override string ToString()
        {
            return string.Join("/", Subtypes);
        }
    }

    interface ISubtypeFilterable
    {
        public SubtypeFilter SubtypeFilter { get; }
    }
}
