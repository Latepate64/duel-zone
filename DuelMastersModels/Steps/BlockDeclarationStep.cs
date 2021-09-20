using DuelMastersModels.Cards;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public class BlockDeclarationStep : TurnBasedActionStep
    {
        internal Creature AttackingCreature { get; private set; }
        internal Creature AttackedCreature { get; private set; }
        internal Creature BlockingCreature { get; set; }

        public BlockDeclarationStep(IPlayer activePlayer, Creature attackingCreature, Creature attackedCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
            AttackedCreature = attackedCreature;
        }

        public override Choice PerformTurnBasedAction()
        {
            // TODO: Check if blocking is possible
            bool possibleToBlock = false;
            if (possibleToBlock)
            {
                return new BlockerChoice(ActivePlayer);
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
                return new BattleStep(ActivePlayer, AttackingCreature, BlockingCreature);
            }
            else if (AttackedCreature != null)
            {
                return new BattleStep(ActivePlayer, AttackingCreature, AttackedCreature);
            }
            else
            {
                return new DirectAttackStep(ActivePlayer, AttackingCreature);
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
