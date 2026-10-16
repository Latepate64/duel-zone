using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IContinuousEffectFactory
{
    IContinuousEffect Create(params ICreature[] creatures);
}
