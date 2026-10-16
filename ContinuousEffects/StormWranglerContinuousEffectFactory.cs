using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class StormWranglerContinuousEffectFactory : IContinuousEffectFactory
{
    public IContinuousEffect Create(params ICreature[] creatures)
    {
        return new StormWranglerContinuousEffect(creatures.Single());
    }
}