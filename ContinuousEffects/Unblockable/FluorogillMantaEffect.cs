using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

/// <summary>
/// Your light creatures and darkness creatures can't be blocked.
/// </summary>
public sealed class FluorogillMantaEffect : ContinuousEffect, IUnblockableEffect
{
    public FluorogillMantaEffect() : base()
    {
    }

    public FluorogillMantaEffect(FluorogillMantaEffect effect) : base(effect)
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (attacker.OwnerV2 != Applier) return false;
        if (!attacker.HasCivilization(
            Civilization.Light, Civilization.Darkness)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new FluorogillMantaEffect(this);
    }
}
