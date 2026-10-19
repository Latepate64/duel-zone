using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class ThisCreatureGetsTwoAbilitiesEffectFactory : IThisCreatureGetsTwoAbilitiesEffectFactory
{
    public IContinuousEffect Create(
        int power,
        IStaticAbilityWithIntegerFactory abilityWithIntegerFactory, 
        IStaticAbilityFactory abilityFactory,
        params ICreature[] creatures)
    {
        return new ThisCreatureGetsTwoAbilitiesEffect(
            creatures.Single(),
            power,
            abilityWithIntegerFactory,
            abilityFactory);
    }
}