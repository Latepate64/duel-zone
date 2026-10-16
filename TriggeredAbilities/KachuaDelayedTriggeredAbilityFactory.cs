using Interfaces;

namespace TriggeredAbilities;

public class KachuaDelayedTriggeredAbilityFactory
    : IKachuaDelayedTriggeredAbilityFactory
{
    public IDelayedTriggeredAbility Create(
        IAbility ability, Guid turn, ICreature creature)
    {
        return new KachuaDelayedTriggeredAbility(ability, creature, turn);
    }
}