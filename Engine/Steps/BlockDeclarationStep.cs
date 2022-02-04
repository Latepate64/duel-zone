using Common.GameEvents;
using Common.Choices;
using Engine.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Steps
{
    public class BlockDeclarationStep : Step
    {
        public BlockDeclarationStep(AttackPhase phase) : base(phase, PhaseOrStep.BlockDeclaration)
        {
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
                ChooseBlocker(game, nonActive, possibleBlockers);
            }
        }

        private void ChooseBlocker(Game game, Player nonActive, IEnumerable<Card> possibleBlockers)
        {
            var blockers = nonActive.Choose(new GuidSelection(game.CurrentTurn.NonActivePlayer, possibleBlockers, 0, 1)).Decision;
            if (blockers.Any())
            {
                Phase.BlockingCreature = blockers.Single();
                var blocker = game.GetCard(Phase.BlockingCreature);
                blocker.Tapped = true;
                game.Process(new BlockEvent { Attacker = game.GetCard(Phase.AttackingCreature).Convert(), Blocker = blocker.Convert() });
            }
        }

        public override Step GetNextStep(Game game)
        {
            if (Phase.BlockingCreature != Guid.Empty)
            {
                return new BattleStep(Phase);
            }
            else if (game.GetAttackable(Phase.AttackTarget) is Card)
            {
                return new BattleStep(Phase);
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
        }
    }
}
