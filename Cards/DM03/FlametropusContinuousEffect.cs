using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM03;

public sealed class FlametropusContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public FlametropusContinuousEffect(FlametropusContinuousEffect effect) : base(effect)
    {
    }

    public FlametropusContinuousEffect(ICard card) : base(card, new StaticAbility(new PowerAttackerEffect(3000)),
        new StaticAbility(new DoubleBreakerEffect()))
    {
    }

    public override IContinuousEffect Copy()
    {
        return new FlametropusContinuousEffect(this);
    }

    public override string ToString()
    {
        return "This creature gets \"power attacker +3000\" and \"double breaker\" until the end of the turn.";
    }
}
