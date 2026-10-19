using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

public class CreaturesCannotBeBlockedEffect : ContinuousEffect, IUnblockableEffect
{
    private readonly ICardFilter attackerFilter;
    private readonly ICardFilter blockerFilter;

    public CreaturesCannotBeBlockedEffect(
        ICardFilter attackerFilter, ICardFilter blockerFilter) : base()
    {
        this.attackerFilter = attackerFilter;
        this.blockerFilter = blockerFilter;
    }

    protected CreaturesCannotBeBlockedEffect(
        CreaturesCannotBeBlockedEffect effect) : base(effect)
    {
        attackerFilter = effect.attackerFilter.Copy();
        blockerFilter = effect.blockerFilter.Copy();
    }

    public virtual bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!attackerFilter.Match(attacker)) return false;
        if (!blockerFilter.Match(blocker)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new CreaturesCannotBeBlockedEffect(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not CreaturesCannotBeBlockedEffect effect) return false;
        if (!attackerFilter.Equals(effect.attackerFilter)) return false;
        if (!blockerFilter.Equals(effect.blockerFilter)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), attackerFilter, blockerFilter);
    }
}
