namespace Engine.Steps
{
    public abstract class PriorityPhase : Phase
    {
        protected internal abstract bool PerformPriorityAction(IGame game);

        protected PriorityPhase(PhaseOrStep type) : base(type)
        {
        }

        protected PriorityPhase(PriorityPhase phase) : base(phase)
        {
        }
    }
}
