using Abilities.Static;
using ContinuousEffects.PowerModifying;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect
    : AddAbilitiesUntilEndOfTurnEffect
{
    public ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(
        int power, params ICreature[] creatures) : base(
            new StaticAbility(new PowerAttackerEffect(power)),
            new DoubleBreakerAbility(),
            creatures)
    {
    }

    public ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(
        ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(this);
    }
}
