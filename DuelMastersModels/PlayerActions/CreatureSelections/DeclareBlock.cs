using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.Steps;
using System;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may declare to block an attacking creature with a blocker.
    /// </summary>
    public class DeclareBlock : OptionalCardSelection<BattleZoneCreature>
    {
        internal DeclareBlock(IPlayer player, IEnumerable<BattleZoneCreature> creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(IDuel duel, BattleZoneCreature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            if (creature != null)
            {
                // 507.1b The chosen creature becomes a blocking creature. It remains a blocking creature until it's removed from the attack or until the end of attack step, whichever comes first.
                BlockDeclarationStep blockDeclarationStep = duel.CurrentTurn.CurrentStep as BlockDeclarationStep;
                blockDeclarationStep.BlockingCreature = creature;
                // 507.1c The nonactive player taps the chosen creature.
                creature.Tapped = true;
                // 507.1d The attacking creature becomes a blocked creature. It remains a blocked creature until it's removed from the attack or until the end of attack step, whichever comes first. A creature remains blocked even if all the blocking creature is removed from the attack.
            }
            return null;
        }
    }
}
