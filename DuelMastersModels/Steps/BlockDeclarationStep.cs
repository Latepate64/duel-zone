using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CreatureSelections;

namespace DuelMastersModels.Steps
{
    internal class BlockDeclarationStep : Step
    {
        internal Creature AttackingCreature { get; private set; }
        internal Creature BlockingCreature { get; set; }

        internal BlockDeclarationStep(Player activePlayer, Creature attackingCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
        }

        internal override PlayerAction PlayerActionRequired(Duel duel)
        {
            return null;
        }

        internal override PlayerAction ProcessTurnBasedActions(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException(nameof(duel));
            }
            Player nonActivePlayer = duel.GetOpponent(ActivePlayer);
            ReadOnlyCreatureCollection creatures = duel.GetCreaturesThatCanBlock(AttackingCreature);
            return creatures.Count > 0 ? new DeclareBlock(nonActivePlayer, creatures) : null;
        }
    }
}
