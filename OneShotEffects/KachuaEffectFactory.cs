using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public class KachuaEffectFactory
{
    public KachuaEffect Create(
        IAbilityAddingContinuousEffectFactory effectFactory,
        IDelayedTriggeredAbilityWithTurnAndCreaturesFactory abilityFactory,
        IAbility ability)
    {
        return new KachuaEffect(effectFactory, abilityFactory, ability);
    }
}