using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.Steps;
using System;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player must declare an attacking creature.
    /// </summary>
    public class DeclareAttackerMandatory : MandatoryCardSelection<BattleZoneCreature>
    {
        internal DeclareAttackerMandatory(Player player, ReadOnlyCreatureCollection<BattleZoneCreature> creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(Duel duel, BattleZoneCreature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
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
                throw new ArgumentNullException(nameof(creature));
            }
        }
    }
}
