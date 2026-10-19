using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Unblockable;

public class CreaturesCannotBeBlockedEffectFactory : IContinuousEffectWithTwoFiltersFactory
{
    public IContinuousEffect Create(ICardFilter attackerFilter, ICardFilter blockerFilter)
    {
        return new CreaturesCannotBeBlockedEffect(attackerFilter, blockerFilter);
    }
}