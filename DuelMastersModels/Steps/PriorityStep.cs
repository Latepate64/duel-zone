using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public abstract class PriorityStep : Step
    {
        protected internal bool PassPriority { get; set; }
        protected internal abstract void PerformPriorityAction(Decision decision, Duel duel);

        protected PriorityStep() { }
        protected PriorityStep(PriorityStep step) : base(step)
        {
            PassPriority = step.PassPriority;
        }
    }
}
