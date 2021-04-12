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
        Ended,
    }

    public interface IStep
    {
        IPlayer ActivePlayer { get; }
        StepState State { get; set; }

        (IChoice, bool) CheckStateBasedActions();
        IStep GetNextStep();
        (IChoice, bool) PerformPriorityAction();
        IChoice PerformTurnBasedAction();
        IChoice Proceed();
        (IChoice, bool) ResolveAbility();
        IChoice Start();
    }
}