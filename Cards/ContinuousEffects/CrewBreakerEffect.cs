using Effects.Continuous;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects;

public abstract class CrewBreakerEffect : ContinuousEffect, IBreakerEffect
{
    protected CrewBreakerEffect(CrewBreakerEffect effect) : base(effect)
    {
    }

    protected CrewBreakerEffect() : base()
    {
        
    }

    public abstract int GetAmount(IGame game, Creature creature);
}
