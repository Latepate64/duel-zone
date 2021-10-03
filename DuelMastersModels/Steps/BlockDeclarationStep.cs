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

        public override Choice PerformTurnBasedAction(Duel duel, Decision decision)
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
            if (BlockingCreature != Guid.Empty)
            {
                return new BattleStep(AttackingCreature, BlockingCreature);
            }
            else if (duel.GetDuelObject(AttackTarget) is Card)
            {
                return new BattleStep(AttackingCreature, AttackTarget);
            }
            else
            {
                return new DirectAttackStep(AttackingCreature);
            }
        }

        public override Step Copy()
        {
            return new BlockDeclarationStep(this);
        }

        public BlockDeclarationStep(BlockDeclarationStep step) : base(step)
        {
            AttackingCreature = step.AttackingCreature;
            AttackTarget = step.AttackTarget;
            BlockingCreature = step.BlockingCreature;
        }
    }
}
