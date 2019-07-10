using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public class DeclareAttacker : OptionalCreatureSelection
    {
        public DeclareAttacker(Player player, Collection<Creature> creatures) : base(player, creatures)
        { }

        public override void Perform(Duel duel, Creature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            if (creature != null)
            {
                creature.Tapped = true;
                AttackDeclarationStep step = (duel.CurrentTurn.CurrentStep as AttackDeclarationStep);
                step.AttackingCreature = creature;
            }
        }
    }
}
