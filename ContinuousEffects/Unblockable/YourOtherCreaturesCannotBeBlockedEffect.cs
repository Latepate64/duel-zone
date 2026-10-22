using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

public sealed class YourOtherCreaturesCannotBeBlockedEffect : YourCreaturesCannotBeBlockedEffect
{
    public YourOtherCreaturesCannotBeBlockedEffect(
        ICardFilter attackerFilter, ICardFilter blockerFilter) : base(attackerFilter, blockerFilter)
    {
    }

    private YourOtherCreaturesCannotBeBlockedEffect(
        YourOtherCreaturesCannotBeBlockedEffect effect) : base(effect)
    {
    }

    public override bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!base.CannotBeBlocked(attacker, blocker, targetOfAttack, battleZone)) return false;
        if (attacker.Equals(Source)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new YourOtherCreaturesCannotBeBlockedEffect(this);
    }
}