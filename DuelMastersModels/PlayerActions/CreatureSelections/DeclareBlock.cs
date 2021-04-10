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
    public class DeclareBlock : OptionalCardSelection<IBattleZoneCreature>
    {
        internal DeclareBlock(IPlayer player, IEnumerable<IBattleZoneCreature> creatures) : base(player, creatures)
        { }

        public override IPlayerAction Perform(IDuel duel, IBattleZoneCreature card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            if (card != null)
            {
                // 507.1b The chosen creature becomes a blocking creature. It remains a blocking creature until it's removed from the attack or until the end of attack step, whichever comes first.
                BlockDeclarationStep blockDeclarationStep = duel.TurnManager.CurrentTurn.CurrentStep as BlockDeclarationStep;
                blockDeclarationStep.BlockingCreature = card;
                // 507.1c The nonactive player taps the chosen creature.
                card.Tapped = true;
                // 507.1d The attacking creature becomes a blocked creature. It remains a blocked creature until it's removed from the attack or until the end of attack step, whichever comes first. A creature remains blocked even if all the blocking creature is removed from the attack.
            }
            return null;
        }
    }
}
