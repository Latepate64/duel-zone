using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneTappedCreatureExceptFilter : OwnersOtherBattleZoneCreatureFilter
    {
        public OwnersBattleZoneTappedCreatureExceptFilter()
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.Tapped;
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneTappedCreatureExceptFilter();
        }

        public override string ToString()
        {
            return $"each other tapped creature you have in the battle zone";
        }
    }
}