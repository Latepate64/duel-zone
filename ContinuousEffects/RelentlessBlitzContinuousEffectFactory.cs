using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class RelentlessBlitzContinuousEffectFactory
    : IContinuousEffectWithRaceFactory
{
    public IContinuousEffect Create(Race race)
    {
        return new RelentlessBlitzContinuousEffect(race);
    }
}