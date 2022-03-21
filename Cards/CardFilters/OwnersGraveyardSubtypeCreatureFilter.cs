using Common;
using Engine;

namespace Cards.CardFilters
{
    class OwnersGraveyardSubtypeCreatureFilter : OwnersGraveyardCreatureFilter, ISubtypeFilterable
    {
        public OwnersGraveyardSubtypeCreatureFilter(Subtype subtype)
        {
            SubtypeFilter = new SubtypeFilter(subtype);
        }

        public OwnersGraveyardSubtypeCreatureFilter(OwnersGraveyardSubtypeCreatureFilter filter) : base(filter)
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
            return new OwnersGraveyardSubtypeCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"a {SubtypeFilter} from your graveyard";
        }
    }
}