using Interfaces;

namespace TriggeredAbilities;

/// <summary>
/// Delayed triggered ability that reads "Whenever X happens, Y happens.".
/// </summary>
public sealed class WheneverSomethingHappensThisTurnAbility : DelayedTriggeredAbility
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
}
