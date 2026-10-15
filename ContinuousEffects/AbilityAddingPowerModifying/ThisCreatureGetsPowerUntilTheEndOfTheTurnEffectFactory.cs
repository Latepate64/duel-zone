using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class ThisCreatureGetsPowerUntilTheEndOfTheTurnEffectFactory
    : IContinuousEffectWithCreaturesAndIntegerFactory
{
    public IContinuousEffect Create(IEnumerable<ICreature> creatures, int power)
    {
        return new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(
            power, [.. creatures]);
    }
}