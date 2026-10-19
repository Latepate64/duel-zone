using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class CreaturesGetAbilitiesEffectFactory : IContinuousEffectWithAbilitiesAndCreaturesFactory
{
    public IContinuousEffect Create(IAbility[] abilities, params ICreature[] creatures)
    {
        return new CreaturesGetAbilitiesEffect(abilities, creatures);
    }
}