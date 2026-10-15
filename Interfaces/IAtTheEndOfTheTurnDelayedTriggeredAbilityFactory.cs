namespace Interfaces;

public interface IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory
{
    IDelayedTriggeredAbility CreateNew(
        IAbility ability, Guid turn, IOneShotEffect effect);
}
