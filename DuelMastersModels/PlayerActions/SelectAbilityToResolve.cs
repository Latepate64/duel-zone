using DuelMastersModels.Abilities;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions
{
    internal class SelectAbilityToResolve : PlayerAction
    {
        internal Collection<NonStaticAbility> Abilities { get; private set; }
        internal NonStaticAbility SelectedAbility { get; set; }

        internal SelectAbilityToResolve(Player player, Collection<NonStaticAbility> abilities) : base(player)
        {
            Abilities = abilities;
        }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            if (Abilities.Count == 1)
            {
                SelectedAbility = Abilities.First();
                duel.CurrentTurn.CurrentStep.PlayerActions.Add(this);
                Perform(duel, Abilities.First());
                return null;
            }
            else
            {
                return this;
            }
        }

        public static void Perform(Duel duel, NonStaticAbility ability)
        {
            duel.PendingAbilities.Remove(ability);
            duel.AbilityBeingResolved = ability;
        }
    }
}
