using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.GameEvents;
using System;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public class BlockDeclarationStep : AttackingCreatureStep
    {
        internal Guid AttackTarget { get; private set; }
        internal Guid BlockingCreature { get; set; }

        public BlockDeclarationStep(Guid attackingCreature, Guid attackTarget)
        {
            AttackingCreature = attackingCreature;
            AttackTarget = attackTarget;
        }

        public override void PerformTurnBasedAction(Game game)
        {
            var nonActive = game.GetPlayer(game.CurrentTurn.NonActivePlayer);
            var possibleBlockers = game.BattleZone.GetCreatures(game.CurrentTurn.NonActivePlayer).Where(x => !x.Tapped && game.GetContinuousEffects<BlockerEffect>(x).Any());
            if (possibleBlockers.Any())
            {
                var effects = game.GetContinuousEffects<UnblockableEffect>(game.GetCard(AttackingCreature));
                possibleBlockers = possibleBlockers.Where(b => effects.All(e => e.BlockerFilter.Applies(b, game, b.Owner)));
            }
            if (possibleBlockers.Any() && !game.GetContinuousEffects<UnblockableEffect>(game.GetCard(AttackingCreature)).Any())
            {
                var dec = nonActive.Choose(new GuidSelection(game.CurrentTurn.NonActivePlayer, possibleBlockers, 0, 1));
                var blockers = dec.Decision;
                if (blockers.Any())
                {
                    BlockingCreature = blockers.Single();
                    var blocker = game.GetCard(BlockingCreature);
                    blocker.Tapped = true;
                    game.Process(new BlockEvent(new Card(game.GetCard(AttackingCreature), true), new Card(blocker, true)));
                }
            }
        }

        public override Step GetNextStep(Game game)
        {
            if (BlockingCreature != Guid.Empty)
            {
                return new BattleStep(AttackingCreature, BlockingCreature);
            }
            else if (game.GetAttackable(AttackTarget) is Card)
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
