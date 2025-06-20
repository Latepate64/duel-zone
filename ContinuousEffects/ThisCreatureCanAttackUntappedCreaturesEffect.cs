using Engine;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureCanAttackUntappedCreaturesEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect
{
    public ThisCreatureCanAttackUntappedCreaturesEffect(ThisCreatureCanAttackUntappedCreaturesEffect effect) : base(
        effect)
    {
    }

    public ThisCreatureCanAttackUntappedCreaturesEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCanAttackUntappedCreaturesEffect(this);
    }

    public override string ToString()
    {
        return "This creature can attack untapped creatures.";
    }

    public bool CanAttackUntappedCreature(Creature attacker, Creature targetOfAttack, IGame game)
    {
        return IsSourceOfAbility(attacker);
    }
}
