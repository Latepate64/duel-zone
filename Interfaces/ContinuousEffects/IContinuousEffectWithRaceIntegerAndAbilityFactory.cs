namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectWithRaceIntegerAndAbilityFactory
{
    IContinuousEffect Create(Race race, IStaticAbilityWithIntegerFactory factory, int integer);
}