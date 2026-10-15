using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IContinuousEffectWithRaceFactory
{
    IContinuousEffect Create(Race race );
}
