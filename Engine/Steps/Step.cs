using Common.GameEvents;

namespace Engine.Steps
{
    public abstract class Step : ITurnBasedActionable
    {
        protected Step(AttackPhase phase, PhaseOrStep type)
        {
            Phase = phase;
            Type = type;
        }

        protected Step(Step step)
        {
            Phase = step.Phase;
            Type = step.Type;
        }

        public AttackPhase Phase { get; }
        public PhaseOrStep Type { get; }

        public abstract Step GetNextStep(IGame game);
        public abstract Step Copy();
        public abstract void PerformTurnBasedAction(IGame game);
    }
}
