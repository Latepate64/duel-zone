using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    public class TargetSpellFilter : SpellFilter
    {
        public Spell Spell { get; private set; }

        public TargetSpellFilter(Spell spell)
        {
            Spell = spell;
        }

        public override ReadOnlySpellCollection FilteredSpells => new ReadOnlySpellCollection(Spell);
    }
}

