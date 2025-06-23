using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class SashaBlockerEffect : ContinuousEffect, IBlockerEffect
{
    public bool CanBlock(ICreature blocker, ICreature attacker, IGame game)
    {
        return attacker.IsDragon;
    }

    public override IContinuousEffect Copy()
    {
        return new SashaBlockerEffect();
    }

    public override string ToString()
    {
        return "Dragon blocker";
    }
}
