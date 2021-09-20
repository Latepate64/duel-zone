using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public abstract class PriorityStep : Step
    {
        protected PriorityStep(IPlayer activePlayer) : base(activePlayer)
        {
        }

        protected internal bool PassPriority { get; set; }
        protected internal abstract Choice PerformPriorityAction(Choice choice);
    }
}
