using DuelMastersModels.Abilities;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    /// <summary>
    /// If there are pending abilities, the active player chooses which one to resolve first among their pending abilities in any order. It does not matter in which order the abilities became pending abilities.
    /// </summary>
    public class SelectAbilityToResolve : Choice
    {
        /// <summary>
        /// If there are pending abilities, the active player chooses which one to resolve first among their pending abilities in any order. It does not matter in which order the abilities became pending abilities.
        /// </summary>
        public List<NonStaticAbility> Abilities { get; private set; }

        internal NonStaticAbility SelectedAbility { get; set; }

        internal SelectAbilityToResolve(IPlayer player, List<NonStaticAbility> abilities) : base(player)
        {
            Abilities = abilities;
        }
    }
}
