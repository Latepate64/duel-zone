using DuelMastersModels.Cards;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    internal class BlockDeclarationStep : Step, ITurnBasedActionable
    {
        internal IBattleZoneCreature AttackingCreature { get; private set; }
        internal IBattleZoneCreature BlockingCreature { get; set; }

        internal BlockDeclarationStep(IPlayer activePlayer, IBattleZoneCreature attackingCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
        }

        public IChoice PerformTurnBasedActions(IDuel duel)
        {
            //IEnumerable<IBattleZoneCreature> creatures = duel.GetCreaturesThatCanBlock(AttackingCreature);
            throw new System.NotImplementedException();
            //return creatures.Any() ? new DeclareBlock(ActivePlayer.Opponent, creatures) : null;
        }
    }
}
