namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectFactory
{
    IContinuousEffect Create(params ICreature[] creatures);
}
