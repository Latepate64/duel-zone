using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// While this creature has power 6000 or more, it has \"double breaker.\"
/// While this creature has power 15000 or more, it has \"triple breaker\"
/// instead of \"double breaker.\"
/// </summary>
public sealed class PoweredTripleBreaker : ContinuousEffect,
    IAbilityAddingEffect
{
    public PoweredTripleBreaker() : base()
    {
    }

    public PoweredTripleBreaker(PoweredTripleBreaker effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        var creature = (ICreature)Source!;
        if (creature.Power >= 15000)
        {
            game.AddAbility(creature, new TripleBreakerAbility());
        }
        else if (creature.Power >= 6000)
        {
            game.AddAbility(creature, new DoubleBreakerAbility());
        }
    }

    public override IContinuousEffect Copy()
    {
        return new PoweredTripleBreaker(this);
    }
}
