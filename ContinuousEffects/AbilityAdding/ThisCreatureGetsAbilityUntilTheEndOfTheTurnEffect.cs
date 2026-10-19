using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect
    : AddAbilitiesUntilEndOfTurnEffect
{
    private readonly IAbility ability;

    public ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
        ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
        ability = effect.ability.Copy();
    }

    public ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
        IAbility ability, params ICard[] cards) : base(ability, cards)
    {
        this.ability = ability;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(this);
    }
}
