using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class CreaturesGetAbilityEffectFactory : IAbilityAddingContinuousEffectFactory
{
    public IContinuousEffect Create(IAbility ability, params ICreature[] creatures)
    {
        return new CreaturesGetAbilityEffect(ability, creatures);
    }
}