using ContinuousEffects.AbilityAdding;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffectFactory
    : IContinuousEffectWithCreaturesAndIntegerFactory
{
    public IContinuousEffect Create(IEnumerable<ICreature> creatures, int power)
    {
        return new ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(
            power, [.. creatures]);
    }
}