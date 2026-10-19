using ContinuousEffects.Unblockable;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class SilvermoonTrailblazerContinuousEffectFactory
    : IContinuousEffectWithRaceFactory
{
    public IContinuousEffect Create(Race race)
    {
        return new SilvermoonTrailblazerContinuousEffect(race);
    }
}