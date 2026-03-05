using Interfaces;

namespace GameEvents.Steps
{
    public sealed class BlockDeclarationStep : Step
    {
        public BlockDeclarationStep(AttackPhase phase) : base(phase, PhaseOrStep.BlockDeclaration)
        {
        }

        public override void PerformTurnBasedAction(IGame game)
        {
            ActivePlayerDeclaresBlocker(game, GetCreaturesThatCanBlock(game, Phase.AttackingCreature));
        }

        private IEnumerable<ICreature> GetCreaturesThatCanBlock(IGame game, ICreature attackingCreature)
        {
            throw new NotImplementedException();
            // var creaturesThatCanBlock = game.BattleZone.GetCreatures(
            //     game.CurrentTurn.NonActivePlayer.Id).Where(creature =>  CanCreatureBlockCreature(
            //         creature, attackingCreature, game));
            // var creaturesThatMustBlock = creaturesThatCanBlock.Where(
            //     creature => game.ContinuousEffects.DoesCreatureBlockIfAble(creature, attackingCreature));
            // return creaturesThatMustBlock.Any() ? creaturesThatMustBlock : creaturesThatCanBlock;
        }

        private bool CanCreatureBlockCreature(ICreature blocker, ICreature attackingCreature, IGame game)
        {
            return !blocker.Tapped &&
                game.ContinuousEffects.CanCreatureBlockCreature(blocker, attackingCreature) &&
                game.ContinuousEffects.CanCreatureBeBlocked(attackingCreature, blocker, Phase.AttackTarget);
        }

        private void ActivePlayerDeclaresBlocker(IGame game, IEnumerable<ICreature> possibleBlockers)
        {
            throw new NotImplementedException();
            // var blocker = game.CurrentTurn.NonActivePlayer.ChooseCreaturesOptionally(possibleBlockers,
            //     "You may choose a creature to block the attack with.");
            // if (blocker != null)
            // {
            //     Phase.BlockingCreature = blocker;
            //     game.CurrentTurn.NonActivePlayer.Tap(game, blocker);
            //     //TODO: Event
            //     //game.Process(new BlockEvent { ICard = blocker.Convert(), BlockedCreature = game.GetCard(Phase.AttackingCreature).Convert() });
            //     game.ProcessEvents(new BecomeBlockedEvent(Phase.AttackingCreature, blocker));
            // }
            // else
            // {
            //     game.ProcessEvents(new BecomeUnblockedEvent(Phase.AttackingCreature));
            // }
        }

        public override Step GetNextStep(IGame game)
        {
            return Phase.BlockingCreature != null
                ? game.ContinuousEffects.DoesBattleHappenAfterCreatureBecomesBlocked(Phase.AttackingCreature, Phase.BlockingCreature)
                    ? new BattleStep(Phase)
                    : new EndOfAttackStep(Phase)
                : Phase.AttackTarget is ICreature
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
