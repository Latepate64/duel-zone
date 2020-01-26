using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may select a creature as the target of the attacking creature. If they do not, their opponent will be attacked.
    /// </summary>
    public class DeclareTargetOfAttack : OptionalCreatureSelection<IBattleZoneCreature>
    {
        internal DeclareTargetOfAttack(Player player, ReadOnlyCreatureCollection<IBattleZoneCreature> creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(Duel duel, IBattleZoneCreature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            AttackDeclarationStep step = duel.CurrentTurn.CurrentStep as AttackDeclarationStep;
            step.AttackedCreature = creature;
            step.TargetOfAttackDeclared = true;
            return null;
        }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return !duel.CanAttackOpponent((duel.CurrentTurn.CurrentStep as AttackDeclarationStep).AttackingCreature) && Cards.Count() == 1
                ? Perform(duel, Cards.First())
                : Cards.Any() ? (this) : Perform(duel, null);
        }
    }
}
