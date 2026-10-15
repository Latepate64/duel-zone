using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class InvincibleUnityContinuousEffectFactory : IContinuousEffectFactory
{
    public IContinuousEffect Create(IEnumerable<ICreature> creatures)
    {
        return new InvincibleUnityContinuousEffect(creatures);
    }
}