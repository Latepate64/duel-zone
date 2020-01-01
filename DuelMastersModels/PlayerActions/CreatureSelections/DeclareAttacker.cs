using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may declare an attacking creature to attack either their opponent or one of their creatures.
    /// </summary>
    public class DeclareAttacker : OptionalCreatureSelection
    {
        internal DeclareAttacker(Player player, ReadOnlyCreatureCollection creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(Duel duel, Creature creature)
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
            return null;
        }
    }
}
