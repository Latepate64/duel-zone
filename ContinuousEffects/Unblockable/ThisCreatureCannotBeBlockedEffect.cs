using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

/// <summary>
/// This creature can't be blocked.
/// </summary>
public sealed class ThisCreatureCannotBeBlockedEffect : ContinuousEffect,
    IUnblockableEffect
{
    public ThisCreatureCannotBeBlockedEffect(
        ThisCreatureCannotBeBlockedEffect effect) : base(effect)
    {
    }

    public ThisCreatureCannotBeBlockedEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeBlockedEffect(this);
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        return true;
    }
}
