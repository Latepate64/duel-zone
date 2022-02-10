using Common.GameEvents;

namespace Engine.Steps
{
    public abstract class PriorityPhase : Phase
    {
        protected internal abstract bool PerformPriorityAction(Game game);

        protected PriorityPhase(PhaseOrStep type) : base(type)
        {
        }

        protected PriorityPhase(PriorityPhase phase) : base(phase)
        {
        }
    }
}
