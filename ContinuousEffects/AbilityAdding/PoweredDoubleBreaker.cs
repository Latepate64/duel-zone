using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// While this creature has power 6000 or more, it has "double breaker."
/// </summary>
public sealed class PoweredDoubleBreaker : ContinuousEffect,
    IAbilityAddingEffect
{
    public PoweredDoubleBreaker() : base()
    {
    }

    public PoweredDoubleBreaker(PoweredDoubleBreaker effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        var creature = (ICreature)Source!;
        if (creature.Power >= 6000)
        {
            game.AddAbility(creature, new DoubleBreakerAbility());
        }
    }

    public override IContinuousEffect Copy()
    {
        return new PoweredDoubleBreaker(this);
    }
}
