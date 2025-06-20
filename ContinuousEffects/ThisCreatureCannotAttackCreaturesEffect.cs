using Engine;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureCannotAttackCreaturesEffect : ContinuousEffect, ICannotAttackCreaturesEffect
{
    public ThisCreatureCannotAttackCreaturesEffect() : base()
    {
    }

    public bool CannotAttackCreature(Creature attacker, Creature target, IGame game)
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
