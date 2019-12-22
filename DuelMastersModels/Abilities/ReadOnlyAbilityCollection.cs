using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Abilities
{
    public class ReadOnlyAbilityCollection : ReadOnlyCollection<Ability>
    {
        public ReadOnlyAbilityCollection(IEnumerable<Ability> abilities) : base(abilities.ToList()) { }
    }

    public class AbilityCollection : ReadOnlyAbilityCollection
    {
        public AbilityCollection() : base(new List<Ability>())
        {
        }

        public void Add(Ability ability)
        {
            Items.Add(ability);
        }
    }
}
