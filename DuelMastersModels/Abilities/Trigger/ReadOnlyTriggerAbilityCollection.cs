using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Abilities.TriggerAbilities
{
    internal class ReadOnlyTriggerAbilityCollection : ReadOnlyCollection<ITriggerAbility>
    {
        internal ReadOnlyTriggerAbilityCollection(IEnumerable<ITriggerAbility> abilities) : base(abilities.ToList()) { }
    }
}
