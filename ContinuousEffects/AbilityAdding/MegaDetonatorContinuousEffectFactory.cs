using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class MegaDetonatorContinuousEffectFactory : IContinuousEffectWithAbilityFactory
{
    public IContinuousEffect Create(IAbility ability, params ICreature[] creatures)
    {
        return new MegaDetonatorContinuousEffect(ability, creatures);
    }
}