using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Breaker;

/// <summary>
/// While this creature has power 6000 or more, it has "double breaker."
/// </summary>
public sealed class PoweredDoubleBreaker : ContinuousEffect, IBreakerEffect
{
    public PoweredDoubleBreaker() : base()
    {
    }

    public PoweredDoubleBreaker(PoweredDoubleBreaker effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new PoweredDoubleBreaker(this);
    }

    public int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(creature)) return 1;
        if (creature.Power < 6000) return 1;
        return 2;
    }
}
