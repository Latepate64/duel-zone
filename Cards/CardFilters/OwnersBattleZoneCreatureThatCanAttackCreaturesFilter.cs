using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCreatureThatCanAttackCreaturesFilter : OwnersBattleZoneCreatureFilter
    {
        public OwnersBattleZoneCreatureThatCanAttackCreaturesFilter() : base()
        {
        }

        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.CanAttackCreatures(game);
        }

        public override string ToString()
        {
            return base.ToString() + " that can attack creatures";
        }
    }
}
