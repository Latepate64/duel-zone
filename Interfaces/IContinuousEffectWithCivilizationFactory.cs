using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IContinuousEffectWithCivilizationFactory
{
    IContinuousEffect Create(Civilization civilization);
}
