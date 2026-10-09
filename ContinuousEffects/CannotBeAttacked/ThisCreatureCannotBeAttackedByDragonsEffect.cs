using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotBeAttacked;

/// <summary>
/// This creature can't be attacked by any creature that has Dragon in its race.
/// </summary>
public sealed class ThisCreatureCannotBeAttackedByDragonsEffect :
    ContinuousEffect, ICannotBeAttackedEffect
{
    public ThisCreatureCannotBeAttackedByDragonsEffect() : base()
    {
    }

    public ThisCreatureCannotBeAttackedByDragonsEffect(
        ThisCreatureCannotBeAttackedByDragonsEffect effect) : base(effect)
    {
    }

    public bool Applies(ICreature attacker, ICreature targetOfAttack)
    {
        if (!IsSourceOfAbility(targetOfAttack)) return false;
        if (!attacker.IsDragon) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeAttackedByDragonsEffect(this);
    }
}
