namespace DuelMastersModels.Steps
{
    public abstract class PriorityPhase : Phase
    {
        protected internal abstract bool PerformPriorityAction(Game game);

        protected PriorityPhase() { }
        protected PriorityPhase(PriorityPhase phase) : base(phase)
        {
        }
    }
}
