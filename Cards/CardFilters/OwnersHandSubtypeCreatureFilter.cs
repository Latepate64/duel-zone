using Common;
using Engine;

namespace Cards.CardFilters
{
    class OwnersHandSubtypeCreatureFilter : OwnersHandCreatureFilter
    {
        private Subtype _subtype;

        public OwnersHandSubtypeCreatureFilter(Subtype subtype)
        {
            _subtype = subtype;
        }

        public OwnersHandSubtypeCreatureFilter(OwnersHandSubtypeCreatureFilter filter) : base(filter)
        {
            _subtype = filter._subtype;
        }

        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.HasSubtype(_subtype);
        }

        public override CardFilter Copy()
        {
            return new OwnersHandSubtypeCreatureFilter(this);
        }
    }
}