using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureCannotBeAttackedEffect : ContinuousEffect, ICannotBeAttackedEffect
{
    public ThisCreatureCannotBeAttackedEffect() : base()
    {
    }

    public bool Applies(ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        return IsSourceOfAbility(targetOfAttack);
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeAttackedEffect();
    }

    public override string ToString()
    {
        return "This creature can't be attacked.";
    }
}
