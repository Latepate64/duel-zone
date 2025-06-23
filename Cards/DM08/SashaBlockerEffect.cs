using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM08;

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
