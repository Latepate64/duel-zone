using DuelMastersModels;
using DuelMastersModels.Zones;
using System;

namespace DuelMastersCards.CardFilters
{
    class CardTypeOwnerZoneFilter : CardFilter
    {
        public OwnerFilter OwnerFilter { get; }
        public ZoneFilter ZoneFilter { get; }
        public CardTypeFilter CardTypeFilter { get; }

        public CardTypeOwnerZoneFilter(bool ownerInsteadOfOpponent, ZoneType zone, CardType cardType)
        {
            OwnerFilter = new OwnerFilter(ownerInsteadOfOpponent);
            ZoneFilter = new ZoneFilter(zone);
            CardTypeFilter = new CardTypeFilter(cardType);
        }

        public CardTypeOwnerZoneFilter(CardTypeOwnerZoneFilter filter) : base(filter)
        {
            OwnerFilter = filter.OwnerFilter.Copy() as OwnerFilter;
            ZoneFilter = filter.ZoneFilter.Copy() as ZoneFilter;
            CardTypeFilter = filter.CardTypeFilter.Copy() as CardTypeFilter;
        }

        public override bool Applies(Card card, Game game, Guid player)
        {
            return OwnerFilter.Applies(card, game, player) && ZoneFilter.Applies(card, game, player) && CardTypeFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new CardTypeOwnerZoneFilter(this);
        }
    }
}
