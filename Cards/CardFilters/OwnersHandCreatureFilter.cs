using Engine;

namespace Cards.CardFilters
{
    class OwnersHandCreatureFilter : OwnersHandCardFilter
    {
        public OwnersHandCreatureFilter()
        {
        }

        public OwnersHandCreatureFilter(OwnersHandCreatureFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new OwnersHandCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()} creature";
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && new CreatureFilter().Applies(card, game, player);
        }
    }
}