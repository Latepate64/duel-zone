using Engine;

namespace Cards.CardFilters
{
    class OwnersOtherBattleZoneUntappedCreatureFilter : OwnersOtherBattleZoneCreatureFilter
    {
        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && !card.Tapped;
        }

        public override CardFilter Copy()
        {
            return new OwnersOtherBattleZoneUntappedCreatureFilter();
        }
    }
}