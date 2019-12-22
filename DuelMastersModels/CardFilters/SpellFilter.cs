using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    public abstract class SpellFilter : CardFilter
    {
        protected SpellFilter()
        {
        }

        public abstract ReadOnlySpellCollection FilteredSpells { get; }
    }
}
