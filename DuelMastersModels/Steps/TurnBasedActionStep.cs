namespace DuelMastersModels.Steps
{
    public abstract class TurnBasedActionStep : Step
    {
        public abstract void PerformTurnBasedAction(Game game);

        protected TurnBasedActionStep() : base() { }
        protected TurnBasedActionStep(TurnBasedActionStep step) : base(step) { }
    }
}