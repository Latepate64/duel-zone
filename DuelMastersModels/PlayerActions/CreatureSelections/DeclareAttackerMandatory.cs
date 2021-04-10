using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.Steps;
using System;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player must declare an attacking creature.
    /// </summary>
    public class DeclareAttackerMandatory : MandatoryCardSelection<BattleZoneCreature>
    {
        internal DeclareAttackerMandatory(IPlayer player, IEnumerable<BattleZoneCreature> creatures) : base(player, creatures)
        { }

        public override IPlayerAction Perform(IDuel duel, BattleZoneCreature card)
        {
            if (card != null)
            {
                card.Tapped = true;
                (duel.CurrentTurn.CurrentStep as AttackDeclarationStep).AttackingCreature = card;
                return null;
            }
            else
            {
                throw new ArgumentNullException(nameof(card));
            }
        }
    }
}
