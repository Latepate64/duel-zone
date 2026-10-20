using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ThisCreatureCannotBeAttackedEffect : ContinuousEffect,
    ICannotBeAttackedEffect
{
    private readonly ICardFilter attackerFilter;

    public ThisCreatureCannotBeAttackedEffect(ICardFilter attackerFilter) : base()
    {
        this.attackerFilter = attackerFilter;
    }

    private ThisCreatureCannotBeAttackedEffect(
        ThisCreatureCannotBeAttackedEffect effect) : base(effect)
    {
        attackerFilter = effect.attackerFilter.Copy();
    }

    public bool Applies(ICreature attacker, ICreature targetOfAttack)
    {
        if (!IsSourceOfAbility(targetOfAttack)) return false;
        if (!attackerFilter.Match(attacker)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeAttackedEffect(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not ThisCreatureCannotBeAttackedEffect effect) return false;
        if (!attackerFilter.Equals(effect.attackerFilter)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), attackerFilter);
    }
}
