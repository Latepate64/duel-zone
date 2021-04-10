using DuelMastersModels.Abilities;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions
{
    /// <summary>
    /// If there are pending abilities, the active player chooses which one to resolve first among their pending abilities in any order. It does not matter in which order the abilities became pending abilities.
    /// </summary>
    public class SelectAbilityToResolve : PlayerAction
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

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            if (Abilities.Count == 1)
            {
                SelectedAbility = Abilities.First();
                Perform(duel, Abilities.First());
                return null;
            }
            else
            {
                return this;
            }
        }

        internal static void Perform(Duel duel, NonStaticAbility ability)
        {
            duel.SetPendingAbilityToBeResolved(ability);
        }
    }
}
