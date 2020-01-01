using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Abilities.Trigger
{
    internal class ReadOnlyTriggerAbilityCollection : ReadOnlyCollection<TriggerAbility>
    {
        internal ReadOnlyTriggerAbilityCollection(IEnumerable<TriggerAbility> abilities) : base(abilities.ToList()) { }
    }
}
