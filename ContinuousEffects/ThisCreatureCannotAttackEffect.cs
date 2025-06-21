using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureCannotAttackEffect : ContinuousEffect, ICannotAttackEffect
{
    public ThisCreatureCannotAttackEffect() : base()
    {
    }

    public bool CannotAttack(ICreature creature, IGame game)
    {
        return IsSourceOfAbility(creature);
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotAttackEffect();
    }

    public override string ToString()
    {
        return "This creature can't attack.";
    }
}
