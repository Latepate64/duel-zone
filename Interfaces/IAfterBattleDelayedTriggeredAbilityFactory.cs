namespace Interfaces;

public interface IDelayedTriggeredAbilityWithEffectAndSourceFactory
{
    IDelayedTriggeredAbility Create(IOneShotEffect effect, IAbility source);
}
