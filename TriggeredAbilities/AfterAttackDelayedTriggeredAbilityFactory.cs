using Interfaces;

namespace TriggeredAbilities;

public class AfterAttackDelayedTriggeredAbilityFactory
    : IDelayedTriggeredAbilityWithEffectAndSourceFactory
{
    public IDelayedTriggeredAbility Create(
        IOneShotEffect effect, IAbility source)
    {
        return new AfterAttackDelayedTriggeredAbility(
            effect, source, source.Id);
    }
}