using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects;

/// <summary>
/// While attacking a creature, this creature can't be blocked.
/// </summary>
public sealed class ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect :
    ContinuousEffect, IUnblockableEffect
{
    public ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect()
    {
    }

    public ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect(
        ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect effect) : base(
            effect)
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (targetOfAttack is not ICreature) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect(
            this);
    }
}
