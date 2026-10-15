using Interfaces;
using TriggeredAbilities;

namespace Cards.DM07;

public class WheneverSomethingHappensThisTurnAbilityFactory : IDelayedTriggeredAbilityFactory
{
    public IDelayedTriggeredAbility Create(ITriggeredAbility ability, IAbility source)
    {
        return new WheneverSomethingHappensThisTurnAbility(ability, source);
    }
}
