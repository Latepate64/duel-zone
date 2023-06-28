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
            ActivePlayerDeclaresBlocker(game, GetCreaturesThatCanBlock(game, Phase.AttackingCreature));
        }

        private IEnumerable<ICard> GetCreaturesThatCanBlock(IGame game, ICard attackingCreature)
        {
            IEnumerable<ICard> creaturesThatCanBlock = game.BattleZone.GetCreatures(game.CurrentTurn.NonActivePlayer).Where(creature =>  CanCreatureBlockCreature(creature, attackingCreature, game));
            IEnumerable<ICard> creaturesThatMustBlock = creaturesThatCanBlock.Where(creature => game.ContinuousEffects.DoesCreatureBlockIfAble(creature, attackingCreature));
            return creaturesThatMustBlock.Any() ? creaturesThatMustBlock : creaturesThatCanBlock;
        }

        private bool CanCreatureBlockCreature(ICard blocker, ICard attackingCreature, IGame game)
        {
            return !blocker.Tapped &&
                game.ContinuousEffects.CanCreatureBlockCreature(blocker, attackingCreature) &&
                game.ContinuousEffects.CanCreatureBeBlocked(attackingCreature, blocker, Phase.AttackTarget);
        }

        private void ActivePlayerDeclaresBlocker(IGame game, IEnumerable<ICard> possibleBlockers)
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
            return Phase.BlockingCreature != null
                ? game.ContinuousEffects.DoesBattleHappenAfterCreatureBecomesBlocked(Phase.AttackingCreature, Phase.BlockingCreature)
                    ? new BattleStep(Phase)
                    : new EndOfAttackStep(Phase)
                : Phase.AttackTarget is ICard
                    ? new BattleStep(Phase)
                    : new DirectAttackStep(Phase);
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
