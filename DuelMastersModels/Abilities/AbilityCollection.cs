using System.Collections.Generic;

namespace DuelMastersModels.Abilities
{
    internal class AbilityCollection : ReadOnlyAbilityCollection
    {
        internal AbilityCollection() : base(new List<IAbility>())
        {
        }

        internal void Add(IAbility ability)
        {
            Items.Add(ability);
        }
    }
}
