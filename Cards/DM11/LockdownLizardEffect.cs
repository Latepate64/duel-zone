using ContinuousEffects;
using Interfaces.ContinuousEffects;

namespace Cards.DM11;

public sealed class LockdownLizardEffect : ContinuousEffect, IPlayersCannotUseTapAbilities
{
    public LockdownLizardEffect()
    {
    }

    public LockdownLizardEffect(IContinuousEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new LockdownLizardEffect(this);
    }

    public override string ToString()
    {
        return "Players can't use the tap abilities of their creatures.";
    }
}
