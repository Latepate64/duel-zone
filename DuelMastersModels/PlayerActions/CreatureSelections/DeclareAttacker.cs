using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.Steps;
using System;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may declare an attacking creature to attack either their opponent or one of their creatures.
    /// </summary>
    public class DeclareAttacker : OptionalCardSelection<BattleZoneCreature>
    {
        internal DeclareAttacker(Player player, IEnumerable<BattleZoneCreature> creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(Duel duel, BattleZoneCreature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            if (creature != null)
            {
                creature.Tapped = true;
                AttackDeclarationStep step = duel.CurrentTurn.CurrentStep as AttackDeclarationStep;
                step.AttackingCreature = creature;
            }
            return null;
        }
    }
}
