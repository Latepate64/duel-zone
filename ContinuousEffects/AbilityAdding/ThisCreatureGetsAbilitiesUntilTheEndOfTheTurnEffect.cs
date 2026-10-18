using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffect
    : AddAbilitiesUntilEndOfTurnEffect
{
    public ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffect(
        IAbility[] abilities, params ICreature[] creatures) : base(abilities, creatures)
    {
    }

    public ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffect(
        ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffect(this);
    }
}
