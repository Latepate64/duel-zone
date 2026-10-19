namespace Interfaces;

public interface IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory
{
    IDelayedTriggeredAbility Create(
        IAbility ability, Guid turn, IOneShotEffect effect);
}
