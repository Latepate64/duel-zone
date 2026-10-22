using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotAttack;

public sealed class ThisCreatureCannotAttackEffect : ContinuousEffect, ICannotAttackEffect
{
    private readonly ICondition? condition;

    public ThisCreatureCannotAttackEffect(ICondition? condition = null) : base()
    {
        this.condition = condition;
    }

    private ThisCreatureCannotAttackEffect(ThisCreatureCannotAttackEffect effect) : base(effect)
    {
        condition = effect.condition;
    }

    public bool CannotAttack(ICreature creature, IGame game)
    {
        if (!IsSourceOfAbility(creature)) return false;
        if (condition == null) return true;
        if (!condition.IsMet(creature)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotAttackEffect(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not ThisCreatureCannotAttackEffect effect) return false;
        if (condition == null && effect.condition != null) return false;
        if (condition != null && !condition.Equals(effect.condition)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), condition);
    }
}
