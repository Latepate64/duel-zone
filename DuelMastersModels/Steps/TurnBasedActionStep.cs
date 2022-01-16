using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public abstract class TurnBasedActionStep : Step
    {
        public abstract void PerformTurnBasedAction(Duel duel, Decision decision);

        protected TurnBasedActionStep() : base() { }
        protected TurnBasedActionStep(TurnBasedActionStep step) : base(step) { }
    }
}