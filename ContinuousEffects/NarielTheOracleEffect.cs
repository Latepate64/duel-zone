using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class NarielTheOracleEffect : ContinuousEffect, ICannotAttackEffect
{
    public NarielTheOracleEffect() : base()
    {
    }

    public bool CannotAttack(ICreature creature, IGame game)
    {
        return creature.Power >= 3000;
    }

    public override IContinuousEffect Copy()
    {
        return new NarielTheOracleEffect();
    }

    public override string ToString()
    {
        return "Creatures that have power 3000 or more can't attack.";
    }
}
