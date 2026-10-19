using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

public sealed class YourCreaturesCannotBeBlockedThisTurnEffect :
    ContinuousEffect, IUnblockableEffect
{
    public YourCreaturesCannotBeBlockedThisTurnEffect() : base()
    {
    }

    public YourCreaturesCannotBeBlockedThisTurnEffect(
        YourCreaturesCannotBeBlockedThisTurnEffect effect) : base(effect)
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
