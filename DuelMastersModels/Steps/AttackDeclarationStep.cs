using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CreatureSelections;
using System.Linq;

namespace DuelMastersModels.Steps
{
    internal class AttackDeclarationStep : Step
    {
        internal Creature AttackingCreature { get; set; }
        internal Creature AttackedCreature { get; set; }
        internal Player NonactivePlayer { get; private set; }
        internal bool TargetOfAttackDeclared { get; set; }

        internal AttackDeclarationStep(Player activePlayer, Player nonactivePlayer) : base(activePlayer)
        {
            NonactivePlayer = nonactivePlayer;
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
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            ReadOnlyCreatureCollection creatures = duel.GetCreaturesThatCanAttack(ActivePlayer);
            if (creatures.Count > 0)
            {
                if (creatures.Any(creature => duel.AttacksIfAble(creature)))
                {
                    return new DeclareAttackerMandatory(ActivePlayer, creatures);
                }
                else
                {
                    return new DeclareAttacker(ActivePlayer, creatures);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
