using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

public sealed class YourCreaturesCannotBeBlockedEffect : ContinuousEffect, IUnblockableEffect
{
    private readonly ICardFilter attackerFilter;

    public YourCreaturesCannotBeBlockedEffect(ICardFilter attackerFilter) : base()
    {
        this.attackerFilter = attackerFilter;
    }

    private YourCreaturesCannotBeBlockedEffect(
        YourCreaturesCannotBeBlockedEffect effect) : base(effect)
    {
        attackerFilter = effect.attackerFilter.Copy();
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!attacker.OwnerV2.Equals(Applier)) return false;
        if (!attackerFilter.Match(attacker)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new YourCreaturesCannotBeBlockedEffect(this);
    }
}
