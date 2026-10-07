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

    public override IContinuousEffect Copy()
    {
        return new PoweredDoubleBreaker();
    }

    public int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        return IsSourceOfAbility(creature) && (Source as ICreature).Power >= 6000 ? 2 : 1;
    }
}
