using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureCannotAttackCreaturesEffect : ContinuousEffect, ICannotAttackCreaturesEffect
{
    public ThisCreatureCannotAttackCreaturesEffect() : base()
    {
    }

    public bool CannotAttackCreature(ICreature attacker, ICreature target, IGame game)
    {
        return IsSourceOfAbility(attacker);
    }

    public override ContinuousEffect Copy()
    {
        return new ThisCreatureCannotAttackCreaturesEffect();
    }

    public override string ToString()
    {
        return "This creature can't attack creatures.";
    }
}
