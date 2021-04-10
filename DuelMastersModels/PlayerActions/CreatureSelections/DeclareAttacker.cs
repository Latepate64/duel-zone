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
    public class DeclareAttacker : OptionalCardSelection<IBattleZoneCreature>
    {
        internal DeclareAttacker(IPlayer player, IEnumerable<IBattleZoneCreature> creatures) : base(player, creatures)
        { }

        public override IPlayerAction Perform(IDuel duel, IBattleZoneCreature card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            if (card != null)
            {
                card.Tapped = true;
                AttackDeclarationStep step = duel.CurrentTurn.CurrentStep as AttackDeclarationStep;
                step.AttackingCreature = card;
            }
            return null;
        }
    }
}
