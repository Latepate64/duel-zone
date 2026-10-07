using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(
        ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
    }

    public ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(params ICard[] cards) : base(new StaticAbility(
        new DoubleBreakerEffect()), cards)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(this);
    }

    public override string ToString()
    {
        return "This creature has \"double breaker\" until the end of the turn.";
    }
}
