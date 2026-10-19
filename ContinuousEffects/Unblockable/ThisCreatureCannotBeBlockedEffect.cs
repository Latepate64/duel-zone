using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

public class ThisCreatureCannotBeBlockedEffect : ContinuousEffect, IUnblockableEffect
{
    private readonly ICardFilter blockerFilter;

    public ThisCreatureCannotBeBlockedEffect(ICardFilter blockerFilter) : base()
    {
        this.blockerFilter = blockerFilter;
    }

    protected ThisCreatureCannotBeBlockedEffect(
        ThisCreatureCannotBeBlockedEffect effect) : base(effect)
    {
        blockerFilter = effect.blockerFilter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeBlockedEffect(this);
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (!blockerFilter.Match(blocker)) return false;
        return true;
    }
}
