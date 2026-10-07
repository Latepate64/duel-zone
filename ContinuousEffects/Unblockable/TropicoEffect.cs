using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

/// <summary>
/// This creature can't be blocked while you have at least 2 other creatures in
/// the battle zone.
/// </summary>
public sealed class TropicoEffect : ContinuousEffect, IUnblockableEffect
{
    public TropicoEffect() : base()
    {
    }

    public TropicoEffect(TropicoEffect effect) : base(effect)
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (battleZone.GetNumberOfOtherCreaturesControllerByPlayer(attacker) < 2) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new TropicoEffect(this);
    }
}
