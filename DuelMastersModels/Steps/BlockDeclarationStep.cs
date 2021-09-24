using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Steps
{
    public class BlockDeclarationStep : TurnBasedActionStep
    {
        internal Guid AttackingCreature { get; private set; }
        internal Guid AttackTarget { get; private set; }
        internal Guid BlockingCreature { get; set; }

        public BlockDeclarationStep(Guid attackingCreature, Guid attackTarget)
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
                throw new NotImplementedException();
                //return new BlockerChoice(duel.CurrentTurn.ActivePlayer);
            }
            else
            {
                return null;
            }
        }

        public override Step GetNextStep(Duel duel)
        {
            if (BlockingCreature != null)
            {
                return new BattleStep(AttackingCreature, BlockingCreature);
            }
            else if (duel.GetCard(AttackTarget) is Creature)
            {
                return new BattleStep(AttackingCreature, AttackTarget);
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
            return Copy(new BlockDeclarationStep(AttackingCreature, AttackTarget)
            {
                BlockingCreature = BlockingCreature
            });
        }
    }
}
