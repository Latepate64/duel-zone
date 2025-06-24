using Interfaces;
using System.Collections.ObjectModel;

namespace GameEvents.Steps
{
    public sealed class AttackPhase : Phase
    {
        public ICreature AttackingCreature { get; internal set; }
        public IAttackable AttackTarget { get; set; }
        public ICreature BlockingCreature { get; set; }

        public AttackPhase() : base(PhaseOrStep.Attack)
        {
        }

        public AttackPhase(AttackPhase step) : base(step)
        {
            AttackingCreature = step.AttackingCreature;
        }

        public override Phase Copy()
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

        public ICreature GetCreatureBattlingAgainst(ICreature card)
        {
            if (card == AttackingCreature)
            {
                if (BlockingCreature != null)
                {
                    return BlockingCreature;
                }
                else if (AttackTarget is ICreature target)
                {
                    return target;
                }
                else
                { 
                    return null;
                }
            }
            else if (card == BlockingCreature || card == AttackTarget)
            {
                return AttackingCreature;
            }
            else
            {
                return null;
            }
        }

        public override Phase GetNextPhase(IGame game)
        {
            return new EndOfTurnPhase();
        }

        internal void RemoveAttackingCreature(IGame game)
        {
            if (AttackingCreature != null)
            {
                throw new NotImplementedException();
                // game.ProcessEvents(new CreatureStoppedAttackingEvent(AttackingCreature, this));
            }
        }

        internal void SetAttackingCreature(ICreature attacker)
        {
            AttackingCreature = attacker;
        }

        public override void Play(IGame game)
        {
            Step step = new AttackDeclarationStep(this);
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

        private readonly Collection<Step> _steps = [];
    }
}
