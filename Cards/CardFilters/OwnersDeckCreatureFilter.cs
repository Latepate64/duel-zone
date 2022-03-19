using Engine;

namespace Cards.CardFilters
{
    class OwnersDeckCreatureFilter : OwnersDeckCardFilter
    {
        public OwnersDeckCreatureFilter()
        {
        }

        public OwnersDeckCreatureFilter(OwnersDeckCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && new CreatureFilter().Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersDeckCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()} creature";
        }
    }
}