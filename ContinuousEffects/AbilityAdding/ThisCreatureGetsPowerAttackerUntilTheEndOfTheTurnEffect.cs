using Abilities.Static;
using ContinuousEffects.PowerModifying;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
{
    private readonly int _power;

    public ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
        _power = effect._power;
    }

    public ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(int power, params ICreature[] creatures) : base(
        new StaticAbility(new PowerAttackerEffect(power)), creatures)
    {
        _power = power;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(this);
    }
}