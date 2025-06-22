using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect(
        ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect effect) : base(effect)
    {
    }

    public ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect(params ICard[] cards) : base(
        new StaticAbility(new ThisCreatureHasBlockerEffect()), cards)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect();
    }

    public override string ToString()
    {
        return "This creature has \"blocker\" until the end of the turn.";
    }
}
