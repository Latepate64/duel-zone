using DuelMastersModels.Cards;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public class BlockDeclarationStep : TurnBasedActionStep
    {
        internal IBattleZoneCreature AttackingCreature { get; private set; }
        internal IBattleZoneCreature AttackedCreature { get; private set; }
        internal IBattleZoneCreature BlockingCreature { get; set; }

        public BlockDeclarationStep(IPlayer activePlayer, IBattleZoneCreature attackingCreature, IBattleZoneCreature attackedCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
            AttackedCreature = attackedCreature;
        }

        public override IChoice PerformTurnBasedAction()
        {
            State = StepState.TurnBasedAction;
            // TODO: Check if blocking is possible
            bool possibleToBlock = false;
            if (possibleToBlock)
            {
                throw new System.NotImplementedException();
            }
            else
            {
                return null;
            }
        }

        public override IStep GetNextStep()
        {
            if (BlockingCreature != null)
            {
                return new BattleStep(ActivePlayer, AttackingCreature, BlockingCreature);
            }
            else if (AttackedCreature != null)
            {
                throw new System.NotImplementedException();
            }
            else
            {
                return new DirectAttackStep(ActivePlayer, AttackingCreature);
            }
        }

        //public IChoice PerformTurnBasedActions(IDuel duel)
        //{
        //    //IEnumerable<IBattleZoneCreature> creatures = duel.GetCreaturesThatCanBlock(AttackingCreature);
        //    throw new System.NotImplementedException();
        //    //return creatures.Any() ? new DeclareBlock(ActivePlayer.Opponent, creatures) : null;
        //}
    }
}
