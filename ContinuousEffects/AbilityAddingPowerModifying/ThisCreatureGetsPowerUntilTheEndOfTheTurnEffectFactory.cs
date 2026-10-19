using ContinuousEffects.PowerModifying;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class ThisCreatureGetsPowerUntilTheEndOfTheTurnEffectFactory
    : IContinuousEffectWithCreaturesAndIntegerFactory
{
    public IContinuousEffect Create(int power, params ICreature[] creatures)
    {
        return new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(
            power, creatures);
    }
}