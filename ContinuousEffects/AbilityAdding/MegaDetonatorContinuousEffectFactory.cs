using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class MegaDetonatorContinuousEffectFactory : IContinuousEffectFactory
{
    public IContinuousEffect Create(params ICreature[] creatures)
    {
        return new MegaDetonatorContinuousEffect(creatures);
    }
}