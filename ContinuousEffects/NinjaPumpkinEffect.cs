using ContinuousEffects.Unblockable;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// This creature gets +x power and can't be blocked.
/// </summary>
public sealed class NinjaPumpkinEffect : ThisCreatureCannotBeBlockedEffect, IPowerModifyingEffect
{
    public NinjaPumpkinEffect(ICardFilter blockerFilter) : base(blockerFilter)
    {
    }

    public NinjaPumpkinEffect(NinjaPumpkinEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new NinjaPumpkinEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        (Source as ICreature).IncreasePower(4000);
    }
}
