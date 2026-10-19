using Interfaces;

namespace TriggeredAbilities;

public class WheneverSomethingHappensThisTurnAbilityFactory : IDelayedTriggeredAbilityFactory
{
    public IDelayedTriggeredAbility Create(
        ITriggeredAbility ability, IAbility source, IDuration? duration)
    {
        return new WheneverSomethingHappensThisTurnAbility(ability, source, duration);
    }
}
