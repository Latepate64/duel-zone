using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect(
        ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect effect) : base(effect)
    {
    }

    public ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect(params Card[] cards) : base(
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
