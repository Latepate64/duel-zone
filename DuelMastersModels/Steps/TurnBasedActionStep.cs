using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public abstract class TurnBasedActionStep : Step
    {
        public abstract Choice PerformTurnBasedAction(Duel duel);
    }
}