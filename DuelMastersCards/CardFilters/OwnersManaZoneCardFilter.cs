using Engine;

namespace Cards.CardFilters
{
    class OwnersManaZoneCardFilter : CardFilter
    {
        public OwnersManaZoneCardFilter()
        {
        }

        public OwnersManaZoneCardFilter(OwnersManaZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && player != null && player.ManaZone.Cards.Contains(card);
        }

        public override CardFilter Copy()
        {
            return new OwnersManaZoneCardFilter(this);
        }
    }
}
