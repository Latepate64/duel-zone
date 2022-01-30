namespace Engine.Steps
{
    public abstract class Step : ITurnBasedActionable
    {
        protected Step(AttackPhase phase)
        {
            Phase = phase;
        }

        protected Step(Step step)
        {
            Phase = step.Phase;
        }

        public AttackPhase Phase { get; }

        public abstract Step GetNextStep(Game game);
        public abstract Step Copy();
        public abstract void PerformTurnBasedAction(Game game);
    }
}
