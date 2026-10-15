using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory
    : IAbilityAddingContinuousEffectFactory
{
    public IContinuousEffect Create(
        IAbility ability, IEnumerable<ICreature> creatures)
    {
        return new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
            ability,
            [.. creatures]);
    }
}