using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotBeAttacked;

/// <summary>
/// This creature can't be attacked.
/// </summary>
public sealed class ThisCreatureCannotBeAttackedEffect : ContinuousEffect,
    ICannotBeAttackedEffect
{
    public ThisCreatureCannotBeAttackedEffect() : base()
    {
    }

    public ThisCreatureCannotBeAttackedEffect(
        ThisCreatureCannotBeAttackedEffect effect) : base(effect)
    {
    }

    public bool Applies(ICreature attacker, ICreature targetOfAttack)
    {
        if (!IsSourceOfAbility(targetOfAttack)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeAttackedEffect(this);
    }
}
