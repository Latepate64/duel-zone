using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCreatureThatCanAttackCreaturesFilter : OwnersBattleZoneCreatureFilter
    {
        public OwnersBattleZoneCreatureThatCanAttackCreaturesFilter() : base()
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.CanAttackCreatures(game);
        }

        public override string ToString()
        {
            return base.ToString() + " that can attack creatures";
        }
    }
}
