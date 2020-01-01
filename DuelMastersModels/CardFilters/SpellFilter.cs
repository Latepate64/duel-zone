using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    internal abstract class SpellFilter : CardFilter
    {
        internal abstract ReadOnlySpellCollection FilteredSpells { get; }
    }
}
