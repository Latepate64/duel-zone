using ContinuousEffects.AbilityAdding;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class GankloakRogueCommandoContinuousEffectFactory
    : IContinuousEffectFactory
{
    public IContinuousEffect Create(IEnumerable<ICreature> creatures)
    {
        return new GankloakRogueCommandoContinuousEffect([.. creatures]);
    }
}