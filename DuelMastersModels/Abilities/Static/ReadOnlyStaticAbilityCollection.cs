using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Abilities.Static
{
    public class ReadOnlyStaticAbilityCollection : ReadOnlyCollection<StaticAbility>
    {
        public ReadOnlyStaticAbilityCollection(IEnumerable<StaticAbility> abilities) : base(abilities.ToList()) { }
    }
}
