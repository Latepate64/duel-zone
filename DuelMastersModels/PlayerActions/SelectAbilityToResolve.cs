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
        public ReadOnlyCollection<INonStaticAbility> Abilities { get; private set; }

        internal INonStaticAbility SelectedAbility { get; set; }

        internal SelectAbilityToResolve(IPlayer player, ReadOnlyCollection<INonStaticAbility> abilities) : base(player)
        {
            Abilities = abilities;
        }

        public override IPlayerAction TryToPerformAutomatically(IDuel duel)
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

        internal static void Perform(IDuel duel, INonStaticAbility ability)
        {
            duel.SetPendingAbilityToBeResolved(ability);
        }
    }
}
