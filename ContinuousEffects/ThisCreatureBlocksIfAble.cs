using Engine;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureBlocksIfAble : ContinuousEffect, IBlocksIfAbleEffect
{
    public ThisCreatureBlocksIfAble() : base()
    {
    }

    public bool BlocksIfAble(ICreature blocker, ICreature attacker, IGame game)
    {
        return IsSourceOfAbility(blocker);
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureBlocksIfAble();
    }

    public override string ToString()
    {
        return "Whenever an opponent's creature attacks, this creature blocks if able.";
    }
}
