using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM04;

public sealed class MegaDetonatorContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public MegaDetonatorContinuousEffect(MegaDetonatorContinuousEffect effect) : base(effect)
    {
    }

    public MegaDetonatorContinuousEffect(params ICard[] cards) : base(
        new StaticAbility(new DoubleBreakerEffect()), cards)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new MegaDetonatorContinuousEffect(this);
    }

    public override string ToString()
    {
        return "This creature gets \"double breaker\" until the end of the turn.";
    }
}
