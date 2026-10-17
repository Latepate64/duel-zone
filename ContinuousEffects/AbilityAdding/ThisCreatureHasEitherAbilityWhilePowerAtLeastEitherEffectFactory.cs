using Interfaces;

namespace ContinuousEffects.AbilityAdding;

public class ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffectFactory
{
    public ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffect Create(
        int lowerGap, IAbility lowerAbility, int higherGap, IAbility higherAbility)
    {
        return new ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffect(
            lowerGap, lowerAbility, higherGap, higherAbility);
    }
}