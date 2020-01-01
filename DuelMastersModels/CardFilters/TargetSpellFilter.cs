using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    internal class TargetSpellFilter : SpellFilter
    {
        internal Spell Spell { get; private set; }

        internal TargetSpellFilter(Spell spell)
        {
            Spell = spell;
        }

        internal override ReadOnlySpellCollection FilteredSpells => new ReadOnlySpellCollection(Spell);
    }
}

