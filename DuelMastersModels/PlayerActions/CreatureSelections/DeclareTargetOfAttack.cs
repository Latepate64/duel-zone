using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public class DeclareTargetOfAttack : OptionalCreatureSelection
    {
        public DeclareTargetOfAttack(Player player, Collection<Creature> creatures) : base(player, creatures)
        { }

        public override PlayerAction Perform(Duel duel, Creature creature)
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

        public override bool PerformAutomatically(Duel duel)
        {
            if (!duel.CanAttackOpponent((duel.CurrentTurn.CurrentStep as AttackDeclarationStep).AttackingCreature) && Creatures.Count == 1)
            {
                Perform(duel, Creatures[0]);
                return true;
            }
            else if (Creatures.Count == 0)
            {
                Perform(duel, null);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
