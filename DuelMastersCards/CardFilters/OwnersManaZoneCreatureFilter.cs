using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    class OwnersManaZoneCreatureFilter : OwnersManaZoneCardFilter
    {
        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.CardType == CardType.Creature;
        }
    }
}
