using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

public sealed class ThisCreatureCannotBeBlockedEffect : ContinuousEffect, IUnblockableEffect
{
    public ThisCreatureCannotBeBlockedEffect() : base()
    {
    }

    private ThisCreatureCannotBeBlockedEffect(
        ThisCreatureCannotBeBlockedEffect effect) : base(effect)
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
