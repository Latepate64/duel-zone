using Engine;

namespace Cards.CardFilters
{
    class OwnersDeckCardWithNameFilter : OwnersDeckCardFilter
    {
        private readonly string _name;

        public OwnersDeckCardWithNameFilter(string name)
        {
            _name = name;
        }

        public OwnersDeckCardWithNameFilter(OwnersDeckCardWithNameFilter filter) : base(filter)
        {
            _name = filter._name;
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.Name == _name;
        }

        public override CardFilter Copy()
        {
            return new OwnersDeckCardWithNameFilter(this);
        }
    }
}