using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCreatureThatCanAttackCreaturesFilter : OwnersBattleZoneCreatureFilter
    {
        public OwnersBattleZoneCreatureThatCanAttackCreaturesFilter() : base()
        {
        }

        public OwnersBattleZoneCreatureThatCanAttackCreaturesFilter(OwnersBattleZoneCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Engine.Card card, Game game, Engine.Player player)
        {
            return base.Applies(card, game, player) && card.CanAttackCreatures(game);
        }

        public override string ToString()
        {
            return base.ToString() + " that can attack creatures";
        }
    }
}
