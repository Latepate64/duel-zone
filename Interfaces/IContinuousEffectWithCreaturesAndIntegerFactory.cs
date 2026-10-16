using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IContinuousEffectWithCreaturesAndIntegerFactory
{
    IContinuousEffect Create(int integer, params ICreature[] creatures);
}