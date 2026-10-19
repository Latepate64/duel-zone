using ContinuousEffects.Unblockable;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class RaceCreaturesCannotBeBlockedEffectFactory : IContinuousEffectWithRaceAndFilterFactory
{
    public IContinuousEffect Create(Race race, ICardFilter blockerFilter)
    {
        return new RaceCreaturesCannotBeBlockedEffect(race, blockerFilter);
    }
}