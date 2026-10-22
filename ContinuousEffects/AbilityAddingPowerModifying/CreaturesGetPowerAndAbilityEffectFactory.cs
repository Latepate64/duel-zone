using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class CreaturesGetPowerAndAbilityEffectFactory
    : IContinuousEffectWithAbilityIntegerAndCreaturesFactory
{
    public IContinuousEffect Create(IAbility ability, int number, params ICreature[] creatures)
    {
        return new CreaturesGetPowerAndAbilityEffect(number, ability, creatures);
    }
}