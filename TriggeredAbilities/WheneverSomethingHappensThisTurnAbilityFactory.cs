using Interfaces;

namespace TriggeredAbilities;

public class WheneverSomethingHappensThisTurnAbilityFactory : IDelayedTriggeredAbilityFactory
{
    public IDelayedTriggeredAbility Create(ITriggeredAbility ability, IAbility source)
    {
        return new WheneverSomethingHappensThisTurnAbility(ability, source);
    }
}
