using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ThisCreatureBlocksIfAbleEffect : ContinuousEffect, IBlocksIfAbleEffect
{
    public ThisCreatureBlocksIfAbleEffect() : base()
    {
    }

    public bool BlocksIfAble(ICreature blocker, ICreature attacker, IGame game)
    {
        return IsSourceOfAbility(blocker);
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureBlocksIfAbleEffect();
    }
}
