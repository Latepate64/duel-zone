using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CanAttackUntappedCreatures;

public class ThisCreatureCanAttackUntappedCreaturesEffect : ContinuousEffect,
    ICanAttackUntappedCreaturesEffect
{
    private readonly ICardFilter targetFilter;

    public ThisCreatureCanAttackUntappedCreaturesEffect(ICardFilter targetFilter) : base()
    {
        this.targetFilter = targetFilter;
    }

    protected ThisCreatureCanAttackUntappedCreaturesEffect(
        ThisCreatureCanAttackUntappedCreaturesEffect effect) : base(effect)
    {
        targetFilter = effect.targetFilter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCanAttackUntappedCreaturesEffect(this);
    }

    public bool CanAttackUntappedCreature(ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (!targetFilter.Match(targetOfAttack)) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not ThisCreatureCanAttackUntappedCreaturesEffect effect) return false;
        if (!targetFilter.Equals(effect.targetFilter)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), targetFilter);
    }
}
