using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CreatureSelections;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Steps
{
    internal class BlockDeclarationStep : Step
    {
        internal IBattleZoneCreature AttackingCreature { get; private set; }
        internal IBattleZoneCreature BlockingCreature { get; set; }

        internal BlockDeclarationStep(IPlayer activePlayer, IBattleZoneCreature attackingCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
        }

        public override IPlayerAction PlayerActionRequired(IDuel duel)
        {
            return null;
        }

        public override IPlayerAction ProcessTurnBasedActions(IDuel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException(nameof(duel));
            }
            IEnumerable<IBattleZoneCreature> creatures = duel.GetCreaturesThatCanBlock(AttackingCreature);
            return creatures.Any() ? new DeclareBlock(ActivePlayer.Opponent, creatures) : null;
        }
    }
}
