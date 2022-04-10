namespace Engine.Steps
{
    public interface IStep
    {
        AttackPhase Phase { get; }
        PhaseOrStep Type { get; }

        IStep Copy();
        IStep GetNextStep(IGame game);
        void PerformTurnBasedAction(IGame game);
    }
}