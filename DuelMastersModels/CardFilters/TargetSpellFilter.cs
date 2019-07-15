using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.CardFilters
{
    public class TargetSpellFilter : SpellFilter
    {
        public Spell Spell { get; private set; }

        public TargetSpellFilter(Spell spell)
        {
            Spell = spell;
        }

        public override Collection<Spell> FilteredSpells
        {
            get { return new Collection<Spell>() { Spell }; }
        }
    }
}

