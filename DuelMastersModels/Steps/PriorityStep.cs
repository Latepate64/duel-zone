namespace DuelMastersModels.Steps
{
    public abstract class PriorityStep : Step
    {
        protected internal abstract bool PerformPriorityAction(Duel duel);

        protected PriorityStep() { }
        protected PriorityStep(PriorityStep step) : base(step)
        {
        }
    }
}
