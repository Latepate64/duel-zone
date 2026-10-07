using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// You can cast this spell only if your opponent has more shields than you do.
/// </summary>
public sealed class MiraculousMeltdownContinuousEffect : ContinuousEffect,
    ICannotUseCardEffect
{
    public MiraculousMeltdownContinuousEffect()
    {
    }

    public MiraculousMeltdownContinuousEffect(
        MiraculousMeltdownContinuousEffect effect) : base(effect)
    {
    }

    public bool Applies(ICard card)
    {
        if (!IsSourceOfAbility(card)) return false;
        if (Applier.ShieldZone.Size < 
            Applier.Opponent.ShieldZone.Size) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new MiraculousMeltdownContinuousEffect(this);
    }
}
