using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM03;

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
