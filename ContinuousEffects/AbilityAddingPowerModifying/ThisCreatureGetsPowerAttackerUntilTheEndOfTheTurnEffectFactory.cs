using ContinuousEffects.AbilityAdding;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffectFactory
    : IContinuousEffectWithCreaturesAndIntegerFactory
{
    public IContinuousEffect Create(int power, params ICreature[] creatures)
    {
        return new ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(
            power, creatures.Single());
    }
}