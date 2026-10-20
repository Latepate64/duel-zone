using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

public class CreaturesGetPowerEffectFactory
    : IContinuousEffectWithCreaturesAndIntegerFactory
{
    public IContinuousEffect Create(int power, params ICreature[] creatures)
    {
        return new CreaturesGetPowerEffect(power, creatures);
    }
}