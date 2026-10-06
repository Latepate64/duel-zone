using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class MiraculousMeltdownContinuousEffect : ContinuousEffect,
    ICannotUseCardEffect
{
    public MiraculousMeltdownContinuousEffect()
    {
    }

    public MiraculousMeltdownContinuousEffect(MiraculousMeltdownContinuousEffect effect) : base(effect)
    {
    }

    public bool Applies(ICard card, IGameState state)
    {
        return card == Source &&
            Applier.ShieldZone.Size >= state.GetOpponent(
                Applier).ShieldZone.Size;
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
