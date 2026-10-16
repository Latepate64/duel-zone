using Abilities.Static;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// This creature gets "double breaker" until the end of the turn.
/// </summary>
public sealed class MegaDetonatorContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public MegaDetonatorContinuousEffect(MegaDetonatorContinuousEffect effect) : base(effect)
    {
    }

    public MegaDetonatorContinuousEffect(params ICard[] cards) : base(
        new DoubleBreakerAbility(), cards)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new MegaDetonatorContinuousEffect(this);
    }
}
