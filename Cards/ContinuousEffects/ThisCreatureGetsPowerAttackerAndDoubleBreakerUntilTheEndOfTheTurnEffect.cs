using Abilities.Static;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects;

public class ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
    }

    public ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(params Card[] cards) : base(new PowerAttackerAbility(4000), new DoubleBreakerAbility(), cards)
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
