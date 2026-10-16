using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class ThreeEyedDragonflyContinuousEffectFactory
    : IContinuousEffectWithCreaturesAndIntegerFactory
{
    public IContinuousEffect Create(int power, params ICreature[] creatures)
    {
        return new ThreeEyedDragonflyContinuousEffect(
            power, creatures.Single());
    }
}