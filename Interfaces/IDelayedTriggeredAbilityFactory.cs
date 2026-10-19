namespace Interfaces;

public interface IDelayedTriggeredAbilityFactory
{
    IDelayedTriggeredAbility Create(
        ITriggeredAbility ability, IAbility source, IDuration? duration);
}
