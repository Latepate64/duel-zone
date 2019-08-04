using DuelMastersModels.Abilities;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions
{
    public class SelectAbilityToResolve : PlayerAction
    {
        public Collection<NonStaticAbility> Abilities { get; private set; }
        public NonStaticAbility SelectedAbility { get; set; }

        public SelectAbilityToResolve(Player player, Collection<NonStaticAbility> abilities) : base(player)
        {
            Abilities = abilities;
        }

        public override PlayerAction TryToPerformAutomatically(Duel duel)
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

        public void Perform(Duel duel, NonStaticAbility ability)
        {
            duel.PendingAbilities.Remove(ability);
            duel.AbilityBeingResolved = ability;
        }
    }
}
