using Engine.ContinuousEffects;
using Engine.GameEvents;
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
            IEnumerable<ICard> possibleBlockers = GetPossibleBlockers(game, Phase.AttackingCreature);
            ChooseBlocker(game, possibleBlockers);
        }

        private IEnumerable<ICard> GetPossibleBlockers(IGame game, ICard attackingCreature)
        {
            var blockers = game.BattleZone.GetCreatures(game.CurrentTurn.NonActivePlayer.Id).Where(blocker =>
                CanBlock(game, attackingCreature, blocker));
            var mustBlockers = blockers.Where(x => game.GetContinuousEffects<IBlocksIfAbleEffect>().Any(e => e.BlocksIfAble(x, attackingCreature, game)));
            if (mustBlockers.Any())
            {
                return mustBlockers;
            }
            else
            {
                return blockers;
            }
        }

        private bool CanBlock(IGame game, ICard attackingCreature, ICard blocker)
        {
            return !blocker.Tapped &&
                game.CanBlock(blocker, attackingCreature) &&
                game.CannotBeBlocked(attackingCreature, blocker, Phase.AttackTarget);
        }

        private void ChooseBlocker(IGame game, IEnumerable<ICard> possibleBlockers)
        {
            var blocker = game.CurrentTurn.NonActivePlayer.ChooseCardOptionally(possibleBlockers, "You may choose a creature to block the attack with.");
            if (blocker != null)
            {
                Phase.BlockingCreature = blocker;
                game.CurrentTurn.NonActivePlayer.Tap(game, blocker);
                //TODO: Event
                //game.Process(new BlockEvent { Card = blocker.Convert(), BlockedCreature = game.GetCard(Phase.AttackingCreature).Convert() });
                game.ProcessEvents(new BecomeBlockedEvent(Phase.AttackingCreature, blocker));
            }
            else
            {
                game.ProcessEvents(new BecomeUnblockedEvent(Phase.AttackingCreature));
            }
        }

        public override IStep GetNextStep(IGame game)
        {
            if (Phase.BlockingCreature != null)
            {
                if (!game.GetContinuousEffects<ISkipBattleAfterBlockEffect>().Any(x => x.Applies(Phase.AttackingCreature, Phase.BlockingCreature, game)))
                {
                    return new BattleStep(Phase);
                }
                else
                {
                    return new EndOfAttackStep(Phase);
                }
            }
            else if (Phase.AttackTarget is ICard)
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
