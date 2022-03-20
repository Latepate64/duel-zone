using Common.GameEvents;
using System;
using System.Collections.ObjectModel;

namespace Engine.Steps
{
    public class AttackPhase : Phase
    {
        public Guid AttackingCreature { get; protected set; }
        public Guid AttackTarget { get; set; }
        public Guid BlockingCreature { get; set; }

        public AttackPhase() : base(PhaseOrStep.Attack)
        {
        }

        public AttackPhase(AttackPhase step) : base(step)
        {
            AttackingCreature = step.AttackingCreature;
        }

        public override IPhase Copy()
        {
            return new AttackPhase(this);
        }

        internal void RemoveAttackTarget(IGame game)
        {
            if (AttackTarget != Guid.Empty)
            {
                var target = game.GetAttackable(AttackTarget);
                AttackTarget = Guid.Empty;
                var e = new AttackTargetRemovedEvent();
                if (target is ICard card)
                {
                    e.TargetCard = card.Convert();
                }
                else if (target is Player player)
                {
                    e.TargetPlayer = player.Convert();
                }
                game.Process(e);
            }
        }

        internal void RemoveBlockingCreature(IGame game)
        {
            if (BlockingCreature != Guid.Empty)
            {
                var blocker = game.GetCard(BlockingCreature);
                BlockingCreature = Guid.Empty;
                game.Process(new CreatureStoppedBlockingEvent { Blocker = blocker.Convert() });
            }
        }

        public override IPhase GetNextPhase(IGame game)
        {
            return new EndOfTurnPhase();
        }

        internal void RemoveAttackingCreature(IGame game)
        {
            if (AttackingCreature != Guid.Empty)
            {
                var attacker = game.GetCard(AttackingCreature);
                AttackingCreature = Guid.Empty;
                game.Process(new CreatureStoppedAttackingEvent { Attacker = attacker.Convert() });
            }
        }

        internal void SetAttackingCreature(ICard attacker, IGame game)
        {
            AttackingCreature = attacker.Id;
        }

        public override void Play(IGame game)
        {
            IStep step = new AttackDeclarationStep(this);
            while (step != null && !game.Ended)
            {
                _steps.Add(step);
                game.Process(new PhaseBegunEvent(step.Type, game.CurrentTurn.Convert()));
                (step as ITurnBasedActionable).PerformTurnBasedAction(game);
                Progress(game);
                step = step.GetNextStep(game);
            }
        }

        private readonly Collection<IStep> _steps = new();
    }
}
