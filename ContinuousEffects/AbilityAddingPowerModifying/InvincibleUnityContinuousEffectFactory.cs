using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class InvincibleUnityContinuousEffectFactory : IContinuousEffectWithAbilityFactory
{
    public IContinuousEffect Create(IAbility ability, params ICreature[] creatures)
    {
        return new InvincibleUnityContinuousEffect(8000, ability, creatures);
    }
}