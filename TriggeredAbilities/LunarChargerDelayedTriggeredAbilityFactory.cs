using Interfaces;

namespace TriggeredAbilities;

public class LunarChargerDelayedTriggeredAbilityFactory
    : IDelayedTriggeredAbilityWithTurnAndCreaturesFactory
{
    public IDelayedTriggeredAbility Create(
        IAbility ability, Guid turn, params ICreature[] creatures)
    {
        return new LunarChargerDelayedTriggeredAbility(
            ability, creatures, turn);
    }
}