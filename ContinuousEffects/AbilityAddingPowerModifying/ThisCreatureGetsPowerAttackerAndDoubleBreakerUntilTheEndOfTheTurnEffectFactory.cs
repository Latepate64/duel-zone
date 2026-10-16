using ContinuousEffects.AbilityAdding;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffectFactory
    : IContinuousEffectWithCreaturesAndIntegerFactory
{
    public IContinuousEffect Create(int power, params ICreature[] creatures)
    {
        return new ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(
            power, creatures);
    }
}