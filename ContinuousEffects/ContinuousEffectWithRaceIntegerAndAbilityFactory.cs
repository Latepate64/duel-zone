using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ContinuousEffectWithRaceIntegerAndAbilityFactory
    : IContinuousEffectWithRaceIntegerAndAbilityFactory
{
    public IContinuousEffect Create(
        Race race,
        IStaticAbilityWithIntegerFactory factory,
        int integer)
    {
        return new EachRaceCreatureAttacksIfAbleAndGetsAbilityEffect(race, factory, integer);
    }
}