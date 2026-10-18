using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffectFactory
    : IContinuousEffectWithAbilitiesAndCreaturesFactory
{
    public IContinuousEffect Create(IAbility[] abilities, params ICreature[] creatures)
    {
        return new ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffect(
            abilities, creatures);
    }
}