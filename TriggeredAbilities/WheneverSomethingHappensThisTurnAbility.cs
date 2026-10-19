using Interfaces;

namespace TriggeredAbilities;

/// <summary>
/// Delayed triggered ability that reads "Whenever X happens, Y happens.".
/// </summary>
public sealed class WheneverSomethingHappensThisTurnAbility : DelayedTriggeredAbility, IExpirable
{
    public WheneverSomethingHappensThisTurnAbility(
        ITriggeredAbility triggeredAbility, IAbility source, IDuration? duration) : base(
            triggeredAbility, source.Source, source.Controller, duration)
    {
    }

    private WheneverSomethingHappensThisTurnAbility(
        WheneverSomethingHappensThisTurnAbility ability) : base(ability)
    {
    }

    public override DelayedTriggeredAbility Copy()
    {
        return new WheneverSomethingHappensThisTurnAbility(this);
    }

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
        // return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
    }
}
