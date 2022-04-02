using Engine;

namespace Cards.CardFilters
{
    class OwnersManaZoneTappedCardFilter : OwnersManaZoneCardFilter
    {
        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.Tapped;
        }

        public override CardFilter Copy()
        {
            return new OwnersManaZoneTappedCardFilter();
        }
    }
}