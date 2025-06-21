using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
{
    private readonly int _power;

    public ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
        _power = effect._power;
    }

    public ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(int power, params ICard[] cards) : base(
        new StaticAbility(new PowerAttackerEffect(power)), cards)
    {
        _power = power;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(this);
    }

    public override string ToString()
    {
        return $"This creature has \"power attacker +{_power}\" until the end of the turn.";
    }
}
