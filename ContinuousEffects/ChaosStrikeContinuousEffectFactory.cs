using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ChaosStrikeContinuousEffectFactory : IContinuousEffectFactory
{
    public IContinuousEffect Create(params ICreature[] creatures)
    {
        return new ChaosStrikeContinuousEffect(creatures.Single());
    }
}