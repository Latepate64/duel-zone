using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public enum StepState
    {
        NotStarted,
        TurnBasedAction,
        StateBasedAction,
        ResolveAbilities,
        PriorityAction,
        Over,
    }

    public interface IStep
    {
        IPlayer ActivePlayer { get; }
        StepState State { get; set; }

        (IChoice, bool) CheckStateBasedActions();
        IStep GetNextStep();
        IChoice Proceed();
        (IChoice, bool) ResolveAbility();
        IChoice Start();
    }
}