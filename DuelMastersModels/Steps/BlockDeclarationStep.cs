using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.GameEvents;
using System;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public class BlockDeclarationStep : Step
    {
        internal Guid AttackTarget { get; private set; }
        internal Guid BlockingCreature { get; set; }

        public BlockDeclarationStep(Guid attackTarget, AttackPhase phase) : base(phase)
        {
            AttackTarget = attackTarget;
        }

        public override void PerformTurnBasedAction(Game game)
        {
            var nonActive = game.GetPlayer(game.CurrentTurn.NonActivePlayer);
            var possibleBlockers = game.BattleZone.GetCreatures(game.CurrentTurn.NonActivePlayer).Where(x => !x.Tapped && game.GetContinuousEffects<BlockerEffect>(x).Any());
            if (possibleBlockers.Any())
            {
                var effects = game.GetContinuousEffects<UnblockableEffect>(game.GetCard(Phase.AttackingCreature));
                possibleBlockers = possibleBlockers.Where(b => effects.All(e => e.BlockerFilter.Applies(b, game, game.GetPlayer(b.Owner))));
            }
            if (possibleBlockers.Any() && !game.GetContinuousEffects<UnblockableEffect>(game.GetCard(Phase.AttackingCreature)).Any())
            {
                var dec = nonActive.Choose(new GuidSelection(game.CurrentTurn.NonActivePlayer, possibleBlockers, 0, 1));
                var blockers = dec.Decision;
                if (blockers.Any())
                {
                    BlockingCreature = blockers.Single();
                    var blocker = game.GetCard(BlockingCreature);
                    blocker.Tapped = true;
                    game.Process(new BlockEvent(new Card(game.GetCard(Phase.AttackingCreature), true), new Card(blocker, true)));
                }
            }
        }

        public override Step GetNextStep(Game game)
        {
            if (BlockingCreature != Guid.Empty)
            {
                return new BattleStep(BlockingCreature, Phase);
            }
            else if (game.GetAttackable(AttackTarget) is Card)
            {
                return new BattleStep(AttackTarget, Phase);
            }
            else
            {
                return new DirectAttackStep(Phase);
            }
        }

        public override Step Copy()
        {
            return new BlockDeclarationStep(this);
        }

        public BlockDeclarationStep(BlockDeclarationStep step) : base(step)
        {
            AttackTarget = step.AttackTarget;
            BlockingCreature = step.BlockingCreature;
        }
    }
}
