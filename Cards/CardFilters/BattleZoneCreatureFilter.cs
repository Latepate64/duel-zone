using Engine;

namespace Cards.CardFilters
{
    class BattleZoneCreatureFilter : BattleZoneCardFilter
    {
        public BattleZoneCreatureFilter() : base()
        {
        }


        public override bool Applies(ICard card, IGame game, IPlayer player)
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
