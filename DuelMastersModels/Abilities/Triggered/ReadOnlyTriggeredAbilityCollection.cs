using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    internal class ReadOnlyTriggeredAbilityCollection : ReadOnlyCollection<ITriggeredAbility>
    {
        internal ReadOnlyTriggeredAbilityCollection(IEnumerable<ITriggeredAbility> abilities) : base(abilities.ToList()) { }
    }
}
