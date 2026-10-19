namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectWithCreaturesAndIntegerFactory
{
    IContinuousEffect Create(int integer, params ICreature[] creatures);
}