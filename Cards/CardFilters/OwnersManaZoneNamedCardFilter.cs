using Engine;

namespace Cards.CardFilters
{
    class OwnersManaZoneNamedCardFilter : OwnersManaZoneCardFilter
    {
        readonly string _name;

        public OwnersManaZoneNamedCardFilter(string name)
        {
            _name = name;
        }

        public OwnersManaZoneNamedCardFilter(OwnersManaZoneNamedCardFilter filter) : base(filter)
        {
            _name = filter._name;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Name == _name;
        }

        public override CardFilter Copy()
        {
            return new OwnersManaZoneNamedCardFilter(this);
        }

        public override string ToString()
        {
            return $"an {_name} in your mana zone";
        }
    }
}