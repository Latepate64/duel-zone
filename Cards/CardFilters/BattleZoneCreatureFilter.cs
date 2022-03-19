using Engine;

namespace Cards.CardFilters
{
    class BattleZoneCreatureFilter : BattleZoneCardFilter
    {
        public BattleZoneCreatureFilter() : base()
        {
        }


        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return base.Applies(card, game, player) && new CreatureFilter().Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new BattleZoneCreatureFilter();
        }

        public override string ToString()
        {
            return "each creature";
        }
    }
}
