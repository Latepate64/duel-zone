using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

public class PowerAttackerEffectFactory : IContinuousEffectWithIntegerFactory
{
    public IContinuousEffect Create(int value)
    {
        return new PowerAttackerEffect(value);
    }
}