using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects;

/// <summary>
/// Your creatures in the battle zone can't be blocked this turn.
/// </summary>
public sealed class YourCreaturesCannotBeBlockedThisTurnEffect :
    UntilEndOfTurnEffect, IUnblockableEffect
{
    public YourCreaturesCannotBeBlockedThisTurnEffect() : base()
    {
    }

    public YourCreaturesCannotBeBlockedThisTurnEffect(
        UntilEndOfTurnEffect effect) : base(effect)
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!attacker.OwnerV2.Equals(Applier)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new YourCreaturesCannotBeBlockedThisTurnEffect(this);
    }
}
