using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IContinuousEffectWithCreaturesAndIntegerFactory
{
    IContinuousEffect Create(IEnumerable<ICreature> creatures, int integer);
}