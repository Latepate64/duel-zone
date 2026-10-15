namespace Interfaces;

public interface IAfterBattleDelayedTriggeredAbilityFactory
{
    IDelayedTriggeredAbility Create(IOneShotEffect effect, IAbility source);
}
