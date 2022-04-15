using Engine.GameEvents;
using System;
using System.Collections.ObjectModel;

namespace Engine.Steps
{
    public class AttackPhase : Phase
    {
        public ICard AttackingCreature { get; internal set; }
        public IAttackable AttackTarget { get; set; }
        public ICard BlockingCreature { get; set; }

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
            if (AttackTarget != null)
            {
                var target = AttackTarget;
                AttackTarget = null;
                //TODO: Event
                //var e = new AttackTargetRemovedEvent();
                //if (target is ICard card)
                //{
                //    e.TargetCard = card.Convert();
                //}
                //else if (target is Player player)
                //{
                //    e.TargetPlayer = player.Convert();
                //}
                //game.Process(e);
            }
        }

        internal void RemoveBlockingCreature(IGame game)
        {
            if (BlockingCreature != null)
            {
                BlockingCreature = null;
                //TODO: Event
                //game.Process(new CreatureStoppedBlockingEvent { Blocker = blocker.Convert() });
            }
        }

        public override IPhase GetNextPhase(IGame game)
        {
            return new EndOfTurnPhase();
        }

        internal void RemoveAttackingCreature(IGame game)
        {
            if (AttackingCreature != null)
            {
                game.ProcessEvents(new CreatureStoppedAttackingEvent(AttackingCreature, this));
            }
        }

        internal void SetAttackingCreature(ICard attacker)
        {
            AttackingCreature = attacker;
        }

        public override void Play(IGame game)
        {
            IStep step = new AttackDeclarationStep(this);
            while (step != null && !game.Ended)
            {
                _steps.Add(step);
                //TODO: Create separate event for changing step?
                //game.Process(new PhaseBegunEvent(step.Type, game.CurrentTurn.Convert()));
                (step as ITurnBasedActionable).PerformTurnBasedAction(game);
                Progress(game);
                step = step.GetNextStep(game);
            }
        }

        private readonly Collection<IStep> _steps = new();
    }
}
