using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AttacksIfAble;

public sealed class CreatureAttacksIfAbleEffect : ContinuousEffect, IAttacksIfAbleEffect
{
    private readonly ICreature creature;

    internal CreatureAttacksIfAbleEffect(ICreature creature)
    {
        this.creature = creature;
    }

    private CreatureAttacksIfAbleEffect(CreatureAttacksIfAbleEffect effect) : base(effect)
    {
        creature = effect.creature;
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return this.creature.Equals(creature);
    }

    public override IContinuousEffect Copy()
    {
        return new CreatureAttacksIfAbleEffect(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not CreatureAttacksIfAbleEffect effect) return false;
        if (!creature.Equals(effect.creature)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), creature);
    }
}
