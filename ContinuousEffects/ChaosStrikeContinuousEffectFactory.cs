using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ChaosStrikeContinuousEffectFactory : IContinuousEffectFactory
{
    public IContinuousEffect Create(IEnumerable<ICreature> creatures)
    {
        return new ChaosStrikeContinuousEffect(creatures.First());
    }
}