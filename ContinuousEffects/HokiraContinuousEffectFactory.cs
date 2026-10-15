using ContinuousEffects.Replacement;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class HokiraContinuousEffectFactory
    : IContinuousEffectWithRaceFactory
{
    public IContinuousEffect Create(Race race)
    {
        return new HokiraContinuousEffect(race);
    }
}