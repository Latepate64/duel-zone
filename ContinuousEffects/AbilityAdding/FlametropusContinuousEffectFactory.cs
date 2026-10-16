using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class FlametropusContinuousEffectFactory
    : IContinuousEffectWithCreaturesAndIntegerFactory
{
    public IContinuousEffect Create(int power, params ICreature[] creatures)
    {
        return new FlametropusContinuousEffect(creatures.Single(), power);
    }
}