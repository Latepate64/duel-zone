using DuelMastersModels.Abilities;
using System.Collections.ObjectModel;

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
        public ReadOnlyCollection<NonStaticAbility> Abilities { get; private set; }

        internal NonStaticAbility SelectedAbility { get; set; }

        internal SelectAbilityToResolve(IPlayer player, ReadOnlyCollection<NonStaticAbility> abilities) : base(player)
        {
            Abilities = abilities;
        }
    }
}
