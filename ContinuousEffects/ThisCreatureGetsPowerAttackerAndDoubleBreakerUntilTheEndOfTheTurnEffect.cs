using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
    }

    public ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(params ICard[] cards) : base(
        new StaticAbility(new PowerAttackerEffect(4000)), new StaticAbility(new DoubleBreakerEffect()), cards)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(this);
    }

    public override string ToString()
    {
        return "This creature has \"power attacker +4000\" and \"double breaker\" until the end of the turn.";
    }
}
