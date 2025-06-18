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

        private IEnumerable<Creature> GetCreaturesThatCanBlock(IGame game, Creature attackingCreature)
        {
            IEnumerable<Creature> creaturesThatCanBlock = game.BattleZone.GetCreatures(game.CurrentTurn.NonActivePlayer.Id).Where(creature =>  CanCreatureBlockCreature(creature, attackingCreature, game));
            IEnumerable<Creature> creaturesThatMustBlock = creaturesThatCanBlock.Where(creature => game.ContinuousEffects.DoesCreatureBlockIfAble(creature, attackingCreature));
            return creaturesThatMustBlock.Any() ? creaturesThatMustBlock : creaturesThatCanBlock;
        }

        private bool CanCreatureBlockCreature(Creature blocker, Creature attackingCreature, IGame game)
        {
            return !blocker.Tapped &&
                game.ContinuousEffects.CanCreatureBlockCreature(blocker, attackingCreature) &&
                game.ContinuousEffects.CanCreatureBeBlocked(attackingCreature, blocker, Phase.AttackTarget);
        }

        private void ActivePlayerDeclaresBlocker(IGame game, IEnumerable<Creature> possibleBlockers)
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

        public override Step GetNextStep(IGame game)
        {
            return Phase.BlockingCreature != null
                ? game.ContinuousEffects.DoesBattleHappenAfterCreatureBecomesBlocked(Phase.AttackingCreature, Phase.BlockingCreature)
                    ? new BattleStep(Phase)
                    : new EndOfAttackStep(Phase)
                : Phase.AttackTarget is Creature
                    ? new BattleStep(Phase)
                    : new DirectAttackStep(Phase);
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
