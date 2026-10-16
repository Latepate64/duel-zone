using Interfaces;

namespace TriggeredAbilities;

public class KachuaDelayedTriggeredAbilityFactory
    : IDelayedTriggeredAbilityWithTurnAndCreaturesFactory
{
    public IDelayedTriggeredAbility Create(
        IAbility ability, Guid turn, params ICreature[] creatures)
    {
        return new KachuaDelayedTriggeredAbility(
            ability, creatures.Single(), turn);
    }
}