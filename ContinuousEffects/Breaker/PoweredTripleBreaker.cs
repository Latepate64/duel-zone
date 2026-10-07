using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Breaker;

/// <summary>
/// While this creature has power 6000 or more, it has \"double breaker.\"
/// While this creature has power 15000 or more, it has \"triple breaker\"
/// instead of \"double breaker.\"
/// </summary>
public sealed class PoweredTripleBreaker : ContinuousEffect, IBreakerEffect
{
    public PoweredTripleBreaker() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new PoweredTripleBreaker();
    }

    public int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(creature)) return 1;
        if (creature.Power < 6000) return 1;
        if (creature.Power < 15000) return 2;
        return 3;
    }
}
