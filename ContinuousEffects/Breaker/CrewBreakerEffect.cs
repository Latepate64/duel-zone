using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Breaker;

public abstract class CrewBreakerEffect : ContinuousEffect, IBreakerEffect
{
    protected CrewBreakerEffect(CrewBreakerEffect effect) : base(effect)
    {
    }

    protected CrewBreakerEffect() : base()
    {
        
    }

    public abstract int GetAmount(ICreature creature, IBattleZone battleZone);
}
