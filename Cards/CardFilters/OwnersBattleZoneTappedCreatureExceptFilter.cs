using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneTappedCreatureExceptFilter : OwnersBattleZoneCreatureExceptFilter
    {
        public OwnersBattleZoneTappedCreatureExceptFilter()
        {
        }

        public OwnersBattleZoneTappedCreatureExceptFilter(OwnersBattleZoneTappedCreatureExceptFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
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