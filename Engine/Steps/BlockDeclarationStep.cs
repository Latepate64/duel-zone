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

        public override void PerformTurnBasedAction(IGame game)
        {
            var nonActive = game.CurrentTurn.NonActivePlayer;
            var attackingCreature = game.GetCard(Phase.AttackingCreature);
            var possibleBlockers = game.BattleZone.GetCreatures(game.CurrentTurn.NonActivePlayer.Id).Where(x => !x.Tapped && game.GetContinuousEffects<BlockerEffect>(x).Any(x => x.BlockableCreatures.Applies(attackingCreature, game, game.GetOwner(attackingCreature))));
            if (possibleBlockers.Any())
            {
                var effects = game.GetContinuousEffects<UnblockableEffect>(attackingCreature);
                possibleBlockers = possibleBlockers.Where(b => effects.All(e => e.BlockerFilter.Applies(b, game, game.GetPlayer(b.Owner))));
            }
            if (possibleBlockers.Any() && !game.GetContinuousEffects<UnblockableEffect>(attackingCreature).Any())
            {
                ChooseBlocker(game, nonActive, possibleBlockers);
            }
        }

        private void ChooseBlocker(IGame game, IPlayer nonActive, IEnumerable<ICard> possibleBlockers)
        {
            var blockers = nonActive.Choose(new BlockerSelection(game.CurrentTurn.NonActivePlayer.Id, possibleBlockers), game).Decision;
            if (blockers.Any())
            {
                Phase.BlockingCreature = blockers.Single();
                var blocker = game.GetCard(Phase.BlockingCreature);
                nonActive.Tap(game, blocker);
                game.Process(new BlockEvent { Card = blocker.Convert(), BlockedCreature = game.GetCard(Phase.AttackingCreature).Convert() });
                game.Process(new BecomeBlockedEvent { Card = game.GetCard(Phase.AttackingCreature).Convert(), Blocker = blocker.Convert() });
            }
        }

        public override IStep GetNextStep(IGame game)
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

        public override IStep Copy()
        {
            return new BlockDeclarationStep(this);
        }

        public BlockDeclarationStep(BlockDeclarationStep step) : base(step)
        {
        }
    }
}
