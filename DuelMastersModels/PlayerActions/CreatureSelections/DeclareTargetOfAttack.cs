using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.Steps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may select a creature as the target of the attacking creature. If they do not, their opponent will be attacked.
    /// </summary>
    public class DeclareTargetOfAttack : OptionalCardSelection<IBattleZoneCreature>
    {
        internal DeclareTargetOfAttack(IPlayer player, IEnumerable<IBattleZoneCreature> creatures) : base(player, creatures)
        { }

        public override IPlayerAction Perform(IDuel duel, IBattleZoneCreature card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            AttackDeclarationStep step = duel.TurnManager.CurrentTurn.CurrentStep as AttackDeclarationStep;
            step.AttackedCreature = card;
            step.TargetOfAttackDeclared = true;
            return null;
        }

        public override IPlayerAction TryToPerformAutomatically(IDuel duel)
        {
            return !duel.CanAttackOpponent((duel.TurnManager.CurrentTurn.CurrentStep as AttackDeclarationStep).AttackingCreature) && Cards.Count() == 1
                ? Perform(duel, Cards.First())
                : Cards.Any() ? (this) : Perform(duel, null);
        }
    }
}
