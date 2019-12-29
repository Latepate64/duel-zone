using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Abilities
{
    public class ReadOnlySpellAbilityCollection : ReadOnlyCollection<SpellAbility>
    {
        internal ReadOnlySpellAbilityCollection(IEnumerable<SpellAbility> abilities) : base(abilities.ToList()) { }
    }
}
