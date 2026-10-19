using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

public class CreaturesCannotBeBlockedEffect : ContinuousEffect, IUnblockableEffect
{
    private readonly ICardFilter attackerFilter;

    public CreaturesCannotBeBlockedEffect(ICardFilter attackerFilter) : base()
    {
        this.attackerFilter = attackerFilter;
    }

    protected CreaturesCannotBeBlockedEffect(CreaturesCannotBeBlockedEffect effect) : base(effect)
    {
        attackerFilter = effect.attackerFilter.Copy();
    }

    public virtual bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!attackerFilter.Match(attacker)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new CreaturesCannotBeBlockedEffect(this);
    }
}