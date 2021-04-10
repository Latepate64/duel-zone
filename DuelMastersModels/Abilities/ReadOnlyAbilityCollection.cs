using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Abilities
{
    internal class ReadOnlyAbilityCollection : ReadOnlyCollection<IAbility>
    {
        internal ReadOnlyAbilityCollection(IEnumerable<IAbility> abilities) : base(abilities.ToList()) { }
    }
}
