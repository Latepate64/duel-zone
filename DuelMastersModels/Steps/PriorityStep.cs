namespace DuelMastersModels.Steps
{
    public abstract class PriorityStep : Step
    {
        protected internal abstract bool PerformPriorityAction(Game game);

        protected PriorityStep() { }
        protected PriorityStep(PriorityStep step) : base(step)
        {
        }
    }
}
