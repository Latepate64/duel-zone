using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public abstract class TurnBasedActionStep : Step
    {
        protected TurnBasedActionStep(IPlayer activePlayer) : base(activePlayer)
        {
        }

        public abstract Choice PerformTurnBasedAction();
    }
}