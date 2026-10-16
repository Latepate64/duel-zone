using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class KachuaContinuousEffectFactory : IContinuousEffectFactory
{
    public IContinuousEffect Create(params ICreature[] creatures)
    {
        return new KachuaContinuousEffect(creatures.Single());
    }
}