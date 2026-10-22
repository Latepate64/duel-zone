using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotAttack;

public sealed class CreaturesCannotAttackEffect : ContinuousEffect, ICannotAttackEffect
{
    private readonly ICardFilter filter;

    public CreaturesCannotAttackEffect(ICardFilter filter) : base()
    {
        this.filter = filter;
    }

    private CreaturesCannotAttackEffect(CreaturesCannotAttackEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public bool CannotAttack(ICreature creature, IGame game)
    {
        return filter.Match(creature);
    }

    public override IContinuousEffect Copy()
    {
        return new CreaturesCannotAttackEffect(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not CreaturesCannotAttackEffect effect) return false;
        if (!filter.Equals(effect.filter)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), filter);
    }
}
