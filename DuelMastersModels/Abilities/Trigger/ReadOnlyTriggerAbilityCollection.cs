using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Abilities.Trigger
{
    public class ReadOnlyTriggerAbilityCollection : ReadOnlyCollection<TriggerAbility>
    {
        public ReadOnlyTriggerAbilityCollection(IEnumerable<TriggerAbility> abilities) : base(abilities.ToList()) { }
    }
}
