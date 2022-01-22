using DuelMastersModels;
using DuelMastersModels.Zones;
using System;


namespace DuelMastersCards.CardFilters
{
    class OwnerZoneFilter : CardFilter
    {
        public OwnerFilter OwnerFilter { get; }
        public ZoneFilter ZoneFilter { get; }

        public OwnerZoneFilter(bool ownerInsteadOfOpponent, ZoneType zone)
        {
            OwnerFilter = new OwnerFilter(ownerInsteadOfOpponent);
            ZoneFilter = new ZoneFilter(zone);
        }

        public OwnerZoneFilter(OwnerZoneFilter filter) : base(filter)
        {
            OwnerFilter = filter.OwnerFilter.Copy() as OwnerFilter;
            ZoneFilter = filter.ZoneFilter.Copy() as ZoneFilter;
        }

        public override bool Applies(Card card, Game game, Guid player)
        {
            return OwnerFilter.Applies(card, game, player) && ZoneFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnerZoneFilter(this);
        }
    }
}
