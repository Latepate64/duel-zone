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
            AttackDeclarationStep step = (duel.CurrentTurn.CurrentStep as AttackDeclarationStep);
            step.AttackedCreature = creature;
            step.TargetOfAttackDeclared = true;
            return null;
        }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            if (!duel.CanAttackOpponent((duel.CurrentTurn.CurrentStep as AttackDeclarationStep).AttackingCreature) && Creatures.Count == 1)
            {
                return Perform(duel, Creatures[0]);
            }
            else if (Creatures.Count == 0)
            {
                return Perform(duel, null);
            }
            else
            {
                return this;
            }
        }
    }
}
