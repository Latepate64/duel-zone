using ContinuousEffects.Unblockable;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ImpossibleTunnelContinuousEffectFactory
    : IContinuousEffectWithRaceFactory
{
    public IContinuousEffect Create(Race race)
    {
        return new ImpossibleTunnelContinuousEffect(race);
    }
}