using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class MiraculousMeltdownContinuousEffect : ContinuousEffect, ICannotUseCardEffect
{
    public MiraculousMeltdownContinuousEffect()
    {
    }

    public MiraculousMeltdownContinuousEffect(MiraculousMeltdownContinuousEffect effect) : base(effect)
    {
    }

    public bool Applies(ICard card, IGame game)
    {
        return card == Source && Controller.ShieldZone.Size >= game.GetOpponent(Controller).ShieldZone.Size;
    }

    public override IContinuousEffect Copy()
    {
        return new MiraculousMeltdownContinuousEffect(this);
    }

    public override string ToString()
    {
        return "You can cast this spell only if your opponent has more shields than you do.";
    }
}
