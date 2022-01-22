using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    class OwnersDeckSpellFilter : OwnersDeckCardFilter
    {
        public OwnersDeckSpellFilter()
        {
        }

        public OwnersDeckSpellFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.CardType == CardType.Spell;
        }

        public override CardFilter Copy()
        {
            return new OwnersDeckSpellFilter(this);
        }
    }
}
