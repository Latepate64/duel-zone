using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IStaticAbilityFactory
{
    IStaticAbility Create(IContinuousEffect effect);
}
