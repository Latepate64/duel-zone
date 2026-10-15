using Interfaces;

namespace TriggeredAbilities;

public class AfterBattleDelayedTriggeredAbilityFactory
    : IAfterBattleDelayedTriggeredAbilityFactory
{
    public IDelayedTriggeredAbility Create(
        IOneShotEffect effect, IAbility source)
    {
        return new AfterBattleDelayedTriggeredAbility(effect, source);
    }
}