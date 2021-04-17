using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class ReadOnlyStaticAbilityCollection : ReadOnlyCollection<IStaticAbility>
    {
        internal ReadOnlyStaticAbilityCollection(IEnumerable<IStaticAbility> abilities) : base(abilities.ToList()) { }
    }
}
