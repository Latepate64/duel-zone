using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IContinuousEffectFactory
{
    IContinuousEffect Create(IEnumerable<ICreature> creatures);
}
