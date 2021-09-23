using DuelMastersModels.Cards;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public class BlockDeclarationStep : TurnBasedActionStep
    {
        internal Creature AttackingCreature { get; private set; }
        internal IAttackable AttackTarget { get; private set; }
        internal Creature BlockingCreature { get; set; }

        public BlockDeclarationStep(Creature attackingCreature, IAttackable attackTarget)
        {
            AttackingCreature = attackingCreature;
            AttackTarget = attackTarget;
        }

        public override Choice PerformTurnBasedAction(Duel duel, Choice choice)
        {
            // TODO: Check if blocking is possible
            bool possibleToBlock = false;
            if (possibleToBlock)
            {
                throw new System.NotImplementedException();
                //return new BlockerChoice(duel.CurrentTurn.ActivePlayer);
            }
            else
            {
                return null;
            }
        }

        public override Step GetNextStep()
        {
            if (BlockingCreature != null)
            {
                return new BattleStep(AttackingCreature, BlockingCreature);
            }
            else if (AttackTarget is Creature creature)
            {
                return new BattleStep(AttackingCreature, creature);
            }
            else
            {
                return new DirectAttackStep(AttackingCreature);
            }
        }

        //public Choice PerformTurnBasedActions(Duel duel)
        //{
        //    //IEnumerable<Creature> creatures = duel.GetCreaturesThatCanBlock(AttackingCreature);
        //    throw new System.NotImplementedException();
        //    //return creatures.Any() ? new DeclareBlock(ActivePlayer.Opponent, creatures) : null;
        //}

        public override Step Copy()
        {
            return Copy(new BlockDeclarationStep(AttackingCreature.Copy() as Creature, AttackTarget.Copy())
            {
                BlockingCreature = BlockingCreature.Copy() as Creature
            });
        }
    }
}
