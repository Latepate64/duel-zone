using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public class DeclareAttackerMandatory : MandatoryCreatureSelection
    {
        public DeclareAttackerMandatory(Player player, ReadOnlyCreatureCollection creatures) : base(player, creatures)
        { }

        public override PlayerAction Perform(Duel duel, Creature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            else if (creature != null)
            {
                creature.Tapped = true;
                AttackDeclarationStep step = (duel.CurrentTurn.CurrentStep as AttackDeclarationStep);
                step.AttackingCreature = creature;
                return null;
            }
            else
            {
                throw new NotSupportedException("Expected attacker.");
            }
        }
    }
}
