using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public class MegaDetonatorDiscardEffectFactory
{
    public MegaDetonatorDiscardEffect Create(
        IContinuousEffectWithAbilityFactory factory, IAbility ability)
    {
        return new MegaDetonatorDiscardEffect(factory, ability);
    }
}