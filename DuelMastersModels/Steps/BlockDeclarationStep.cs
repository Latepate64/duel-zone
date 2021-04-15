using DuelMastersModels.Cards;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public class BlockDeclarationStep : TurnBasedActionStep
    {
        internal IBattleZoneCreature AttackingCreature { get; private set; }
        internal IBattleZoneCreature BlockingCreature { get; set; }

        public BlockDeclarationStep(IPlayer activePlayer, IBattleZoneCreature attackingCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
        }

        public override IChoice PerformTurnBasedAction()
        {
            State = StepState.TurnBasedAction;
            throw new System.NotImplementedException();
        }

        public override IStep GetNextStep()
        {
            throw new System.NotImplementedException();
            //AttackDeclarationStep lastAttackDeclaration = Steps.Where(step => step is AttackDeclarationStep).Cast<AttackDeclarationStep>().Last();
            //return new BattleStep(ActivePlayer, lastAttackDeclaration.AttackingCreature, lastAttackDeclaration.AttackedCreature, blockDeclarationStep.BlockingCreature);
        }

        //public IChoice PerformTurnBasedActions(IDuel duel)
        //{
        //    //IEnumerable<IBattleZoneCreature> creatures = duel.GetCreaturesThatCanBlock(AttackingCreature);
        //    throw new System.NotImplementedException();
        //    //return creatures.Any() ? new DeclareBlock(ActivePlayer.Opponent, creatures) : null;
        //}
    }
}
