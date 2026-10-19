using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Unblockable;

public class ThisCreatureCannotBeBlockedEffectFactory
{
    public IContinuousEffect Create(ICardFilter blockerFilter)
    {
        return new ThisCreatureCannotBeBlockedEffect(blockerFilter);
    }
}