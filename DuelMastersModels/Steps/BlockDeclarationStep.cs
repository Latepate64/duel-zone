using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using System;
using System.Linq;

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
            if (decision == null)
            {
                var nonActive = duel.GetPlayer(duel.CurrentTurn.NonActivePlayer);
                var possibleBlockers = nonActive.BattleZone.Creatures.Where(x => !x.Tapped && duel.GetContinuousEffects<BlockerEffect>(x).Any());
                if (possibleBlockers.Any())
                {
                    return new GuidSelection(duel.CurrentTurn.NonActivePlayer, possibleBlockers, 0, 1);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                var blockers = (decision as GuidDecision).Decision;
                if (blockers.Any())
                {
                    BlockingCreature = blockers.Single();
                    duel.GetPermanent(BlockingCreature).Tapped = true;
                }
                return null;
            }
        }

        public override Step GetNextStep(Duel duel)
        {
            if (BlockingCreature != Guid.Empty)
            {
                return new BattleStep(AttackingCreature, BlockingCreature);
            }
            else if (duel.GetAttackable(AttackTarget) is Card)
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
