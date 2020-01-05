using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may select a creature as the target of the attacking creature. If they do not, their opponent will be attacked.
    /// </summary>
    public class DeclareTargetOfAttack : OptionalCreatureSelection
    {
        internal DeclareTargetOfAttack(Player player, ReadOnlyCreatureCollection creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(Duel duel, Creature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            AttackDeclarationStep step = duel.CurrentTurn.CurrentStep as AttackDeclarationStep;
            step.AttackedCreature = creature;
            step.TargetOfAttackDeclared = true;
            return null;
        }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return !duel.CanAttackOpponent((duel.CurrentTurn.CurrentStep as AttackDeclarationStep).AttackingCreature) && Creatures.Count == 1
                ? Perform(duel, Creatures[0])
                : Creatures.Count == 0 ? Perform(duel, null) : (this);
        }
    }
}
