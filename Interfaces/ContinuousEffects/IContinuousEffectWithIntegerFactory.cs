namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectWithIntegerFactory
{
    IContinuousEffect Create(int value);
}