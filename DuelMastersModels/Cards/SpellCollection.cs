using System.Collections.Generic;

namespace DuelMastersModels.Cards
{
    internal class SpellCollection : ReadOnlySpellCollection
    {
        internal SpellCollection() : base(new List<Spell>())
        {
        }

        internal void Add(Spell spell)
        {
            Items.Add(spell);
        }

        internal void Remove(Spell spell)
        {
            Items.Remove(spell);
        }
    }
}
