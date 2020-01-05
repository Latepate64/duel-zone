using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player must declare an attacking creature.
    /// </summary>
    public class DeclareAttackerMandatory : MandatoryCreatureSelection
    {
        internal DeclareAttackerMandatory(Player player, ReadOnlyCreatureCollection creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(Duel duel, Creature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            else if (creature != null)
            {
                creature.Tapped = true;
                AttackDeclarationStep step = duel.CurrentTurn.CurrentStep as AttackDeclarationStep;
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
