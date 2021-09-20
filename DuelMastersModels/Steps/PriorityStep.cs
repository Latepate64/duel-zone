using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public abstract class PriorityStep : Step
    {
        protected internal bool PassPriority { get; set; }
        protected internal abstract Choice PerformPriorityAction(Choice choice, Duel duel);
    }
}
