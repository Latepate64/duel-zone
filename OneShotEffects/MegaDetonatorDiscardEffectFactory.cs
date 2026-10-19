using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public class MegaDetonatorDiscardEffectFactory
{
    public MegaDetonatorDiscardEffect Create(
        IAbilityAddingContinuousEffectFactory factory, IAbility ability)
    {
        return new MegaDetonatorDiscardEffect(factory, ability);
    }
}