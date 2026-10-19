using Interfaces;

namespace ContinuousEffects.AbilityAdding;

public class ThisCreatureHasAbilityWhilePowerAtLeastEffectFactory
{
    public ThisCreatureHasAbilityWhilePowerAtLeastEffect Create(int power, IAbility ability)
    {
        return new ThisCreatureHasAbilityWhilePowerAtLeastEffect(power, ability);
    }
}