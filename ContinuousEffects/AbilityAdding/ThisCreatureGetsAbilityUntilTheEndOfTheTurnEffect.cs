using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect
    : AddAbilitiesUntilEndOfTurnEffect
{
    internal ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
        IAbility ability, params ICard[] cards) : base(ability, cards)
    {
    }

    private ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
        ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(this);
    }
}
