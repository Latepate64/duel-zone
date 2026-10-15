using Interfaces;

namespace TriggeredAbilities;

public class AfterBattleDelayedTriggeredAbilityFactory
    : IDelayedTriggeredAbilityWithEffectAndSourceFactory
{
    public IDelayedTriggeredAbility Create(
        IOneShotEffect effect, IAbility source)
    {
        return new AfterBattleDelayedTriggeredAbility(effect, source);
    }
}
