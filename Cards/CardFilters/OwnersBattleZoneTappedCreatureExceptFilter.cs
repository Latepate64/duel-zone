using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneTappedCreatureExceptFilter : OwnersBattleZoneCreatureExceptFilter
    {
        public OwnersBattleZoneTappedCreatureExceptFilter()
        {
        }

        public override bool Applies(Card card, Game game, IPlayer player)
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