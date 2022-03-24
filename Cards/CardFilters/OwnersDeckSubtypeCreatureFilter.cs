using Common;
using Engine;

namespace Cards.CardFilters
{
    class OwnersDeckSubtypeCreatureFilter : OwnersDeckCreatureFilter, ISubtypeFilterable
    {
        public OwnersDeckSubtypeCreatureFilter(Subtype subtype)
        {
            SubtypeFilter = new SubtypeFilter(subtype);
        }

        public OwnersDeckSubtypeCreatureFilter(OwnersDeckSubtypeCreatureFilter filter) : base(filter)
        {
            SubtypeFilter = filter.SubtypeFilter;
        }

        public SubtypeFilter SubtypeFilter { get; }

        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && SubtypeFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersDeckSubtypeCreatureFilter(this);
        }

        public override string ToString()
        {
            return SubtypeFilter.ToString();
        }
    }
}