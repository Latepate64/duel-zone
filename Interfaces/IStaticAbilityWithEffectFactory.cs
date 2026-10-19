using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IStaticAbilityWithEffectFactory
{
    IStaticAbility Create(IContinuousEffect effect);
}
