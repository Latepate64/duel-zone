using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Breaker;

/// <summary>
/// "While this creature has power 6000 or more, it has \"double breaker.\"
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
        if (IsSourceOfAbility(creature))
        {
            var power = (Source as ICreature).Power;
            return power >= 15000 ?
                3 :
                power >= 6000 ?
                    2 :
                    1;
        }
        else
        {
            return 1;
        }
    }
}
