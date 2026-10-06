using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// Each of your other creatures in the battle zone that has power 5000 or more
/// breaks one more shield.
/// </summary>
public sealed class DynoMantisEffect : ContinuousEffect, 
    IBreaksAdditionalShieldsEffect
{
    public DynoMantisEffect()
    {
    }

    public DynoMantisEffect(DynoMantisEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new DynoMantisEffect(this);
    }

    public int GetAmount(ICreature creature)
    {
        if (creature.OwnerV2 != Applier) return 0;
        if (IsSourceOfAbility(creature)) return 0;
        if (creature.Power < 5000) return 0;
        return 1;
    }
}
