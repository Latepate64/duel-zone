using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class ContinuousEffectWithAbilityFactory : IContinuousEffectWithStaticAbilityFactoryFactory
{
    public IContinuousEffect Create(IStaticAbilityFactory factory, params ICreature[] creatures)
    {
        return new EachOfYourCreaturesHasAbilityUntilStartOfYourNextTurnEffect(factory, creatures);
    }
}