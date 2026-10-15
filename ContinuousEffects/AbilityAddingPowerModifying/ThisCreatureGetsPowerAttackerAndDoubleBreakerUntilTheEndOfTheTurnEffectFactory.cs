using ContinuousEffects.AbilityAdding;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffectFactory
    : IContinuousEffectWithCreaturesAndIntegerFactory
{
    public IContinuousEffect Create(IEnumerable<ICreature> creatures, int power)
    {
        return new ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(
            power, [.. creatures]);
    }
}