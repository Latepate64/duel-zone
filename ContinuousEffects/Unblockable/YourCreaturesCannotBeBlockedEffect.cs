using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

public class YourCreaturesCannotBeBlockedEffect : CreaturesCannotBeBlockedEffect
{
    public YourCreaturesCannotBeBlockedEffect(ICardFilter attackerFilter) : base(attackerFilter)
    {
    }

    protected YourCreaturesCannotBeBlockedEffect(
        YourCreaturesCannotBeBlockedEffect effect) : base(effect)
    {
    }

    public override bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!base.CannotBeBlocked(attacker, blocker, targetOfAttack, battleZone)) return false;
        if (!attacker.OwnerV2.Equals(Applier)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new YourCreaturesCannotBeBlockedEffect(this);
    }
}
