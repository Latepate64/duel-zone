namespace DuelMastersModels.Steps
{
    public abstract class TurnBasedActionStep : Step
    {
        public abstract void PerformTurnBasedAction(Duel duel);

        protected TurnBasedActionStep() : base() { }
        protected TurnBasedActionStep(TurnBasedActionStep step) : base(step) { }
    }
}