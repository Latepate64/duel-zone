using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    internal class ReadOnlySpellCollection : ReadOnlyCollection<Spell>
    {
        internal ReadOnlySpellCollection(IEnumerable<Spell> spells) : base(spells.ToList()) { }

        internal ReadOnlySpellCollection(Spell spell) : base(new List<Spell>() { spell }) { }
    }
}
