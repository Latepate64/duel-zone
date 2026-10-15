using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class GigiosHammerContinuousEffectFactory
    : IContinuousEffectWithRaceFactory
{
    public IContinuousEffect Create(Race race)
    {
        return new GigiosHammerContinuousEffect(race);
    }
}