using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ThisCreatureCannotAttackCreaturesEffect : ContinuousEffect,
    ICannotAttackCreaturesEffect
{
    private readonly ICardFilter targetFilter;

    public ThisCreatureCannotAttackCreaturesEffect(ICardFilter targetFilter) : base()
    {
        this.targetFilter = targetFilter;
    }

    private ThisCreatureCannotAttackCreaturesEffect(
        ThisCreatureCannotAttackCreaturesEffect effect) : base()
    {
        targetFilter = effect.targetFilter.Copy();
    }

    public bool CannotAttackCreature(ICreature attacker, ICreature target, IGame game)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (!targetFilter.Match(target)) return false;
        return true;
    }

    public override ContinuousEffect Copy()
    {
        return new ThisCreatureCannotAttackCreaturesEffect(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not ThisCreatureCannotAttackCreaturesEffect effect) return false;
        if (!targetFilter.Equals(effect.targetFilter)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), targetFilter);
    }
}
