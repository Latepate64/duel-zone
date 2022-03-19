using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCreatureFilter : OwnersBattleZoneCardFilter
    {
        public OwnersBattleZoneCreatureFilter() : base()
        {
        }

        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return base.Applies(card, game, player) && new CreatureFilter().Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneCreatureFilter();
        }

        public override string ToString()
        {
            return $"your creatures";
        }
    }
}
