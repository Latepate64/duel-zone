using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Breaker;

public abstract class CrewBreakerEffect : ContinuousEffect, IBreakerEffect
{
    protected CrewBreakerEffect(CrewBreakerEffect effect) : base(effect)
    {
    }

    protected CrewBreakerEffect() : base()
    {
        
    }

    public abstract int GetAmount(IGame game, ICreature creature);
}
