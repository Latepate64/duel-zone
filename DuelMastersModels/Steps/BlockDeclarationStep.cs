using DuelMastersModels.Cards;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public class BlockDeclarationStep : TurnBasedActionStep
    {
        internal Creature AttackingCreature { get; private set; }
        internal Creature AttackedCreature { get; private set; }
        internal Creature BlockingCreature { get; set; }

        public BlockDeclarationStep(Creature attackingCreature, Creature attackedCreature)
        {
            AttackingCreature = attackingCreature;
            AttackedCreature = attackedCreature;
        }

        public override Choice PerformTurnBasedAction(Duel duel)
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
            else if (AttackedCreature != null)
            {
                return new BattleStep(AttackingCreature, AttackedCreature);
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
    }
}
