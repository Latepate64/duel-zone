using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public interface IPriorityStep
    {
        IChoice PerformPriorityAction();
    }
}