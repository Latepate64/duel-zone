using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CreatureSelections;
using System.Linq;

namespace DuelMastersModels.Steps
{
    internal class AttackDeclarationStep : Step
    {
        internal IBattleZoneCreature AttackingCreature { get; set; }
        internal IBattleZoneCreature AttackedCreature { get; set; }
        internal bool TargetOfAttackDeclared { get; set; }

        internal AttackDeclarationStep(Player activePlayer) : base(activePlayer)
        {
        }

        internal override PlayerAction PlayerActionRequired(Duel duel)
        {
            if (AttackingCreature != null && !TargetOfAttackDeclared)
            {
                //TODO: If attacked creature is not null, check that it can be attacked.
                return new DeclareTargetOfAttack(ActivePlayer, duel.GetCreaturesThatCanBeAttacked(ActivePlayer));
            }
            else
            {
                return null;
            }
        }

        internal override PlayerAction ProcessTurnBasedActions(Duel duel)
        {
            ReadOnlyCreatureCollection<BattleZoneCreature> creatures = duel.GetCreaturesThatCanAttack(ActivePlayer);
            return creatures.Count > 0
                ? creatures.Any(creature => duel.AttacksIfAble(creature))
                    ? new DeclareAttackerMandatory(ActivePlayer, creatures)
                    : (PlayerAction)new DeclareAttacker(ActivePlayer, creatures)
                : null;
        }
    }
}
