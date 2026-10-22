using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public class KachuaEffectFactory
{
    public KachuaEffect Create(
        IContinuousEffectWithAbilitiesAndCreaturesFactory effectFactory,
        IDelayedTriggeredAbilityWithTurnAndCreaturesFactory abilityFactory,
        IAbility ability,
        IDuration duration)
    {
        return new KachuaEffect(effectFactory, abilityFactory, ability, duration);
    }
}