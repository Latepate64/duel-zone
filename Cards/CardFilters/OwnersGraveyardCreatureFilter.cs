using Engine;

namespace Cards.CardFilters
{
    class OwnersGraveyardCreatureFilter : OwnersGraveyardCardFilter
    {
        public OwnersGraveyardCreatureFilter() : base()
        {
        }

        public OwnersGraveyardCreatureFilter(OwnersGraveyardCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Engine.Card card, Game game, Engine.Player player)
        {
            return base.Applies(card, game, player) && new CreatureFilter().Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersGraveyardCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()} creature";
        }
    }
}