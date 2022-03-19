using Common.GameEvents;

namespace Engine.Steps
{
    public abstract class Step : ITurnBasedActionable, IStep
    {
        protected Step(AttackPhase phase, PhaseOrStep type)
        {
            Phase = phase;
            Type = type;
        }

        protected Step(IStep step)
        {
            Phase = step.Phase;
            Type = step.Type;
        }

        public AttackPhase Phase { get; }
        public PhaseOrStep Type { get; }

        public abstract IStep GetNextStep(IGame game);
        public abstract IStep Copy();
        public abstract void PerformTurnBasedAction(IGame game);
    }
}
