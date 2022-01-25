using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    class OwnersGraveyardSpellFilter : OwnersGraveyardCardFilter
    {
        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.CardType == CardType.Spell;
        }
    }
}
