using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class MegaDetonatorContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
{
    internal MegaDetonatorContinuousEffect(IAbility ability, params ICard[] cards) : base(
        ability, cards)
    {
    }

    private MegaDetonatorContinuousEffect(MegaDetonatorContinuousEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new MegaDetonatorContinuousEffect(this);
    }
}