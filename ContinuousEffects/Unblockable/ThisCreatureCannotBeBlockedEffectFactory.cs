using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Unblockable;

public class ThisCreatureCannotBeBlockedEffectFactory
{
    public IContinuousEffect Create()
    {
        return new ThisCreatureCannotBeBlockedEffect();
    }
}