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
            var attackingCreature = game.GetCard(Phase.AttackingCreature);
            IEnumerable<ICard> possibleBlockers = GetPossibleBlockers(game, attackingCreature);
            ChooseBlocker(game, possibleBlockers);
        }

        private static IEnumerable<ICard> GetPossibleBlockers(IGame game, ICard attackingCreature)
        {
            var blockers = game.BattleZone.GetCreatures(game.CurrentTurn.NonActivePlayer.Id).Where(blocker =>
                CanBlock(game, attackingCreature, blocker));
            var mustBlockers = blockers.Where(x => game.GetContinuousEffects<IBlocksIfAbleEffect>(x).Any(e => e.Applies(x, game)));
            if (mustBlockers.Any())
            {
                return mustBlockers;
            }
            else
            {
                return blockers;
            }
        }

        private static bool CanBlock(IGame game, ICard attackingCreature, ICard blocker)
        {
            return !blocker.Tapped &&
                game.GetContinuousEffects<IBlockerEffect>(blocker).Any(e => e.Applies(blocker, attackingCreature, game)) &&
                game.GetContinuousEffects<IUnblockableEffect>(attackingCreature).All(e => !e.Applies(attackingCreature, blocker, game));
        }

        private void ChooseBlocker(IGame game, IEnumerable<ICard> possibleBlockers)
        {
            var blockers = game.CurrentTurn.NonActivePlayer.Choose(new BlockerSelection(game.CurrentTurn.NonActivePlayer.Id, possibleBlockers), game).Decision;
            if (blockers.Any())
            {
                Phase.BlockingCreature = blockers.Single();
                var blocker = game.GetCard(Phase.BlockingCreature);
                game.CurrentTurn.NonActivePlayer.Tap(game, blocker);
                game.Process(new BlockEvent { Card = blocker.Convert(), BlockedCreature = game.GetCard(Phase.AttackingCreature).Convert() });
                game.Process(new BecomeBlockedEvent { Card = game.GetCard(Phase.AttackingCreature).Convert(), Blocker = blocker.Convert() });
            }
            else
            {
                game.Process(new BecomeUnblockedEvent { Card = game.GetCard(Phase.AttackingCreature).Convert() });
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
