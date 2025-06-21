using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureHasBlockerEffect : ContinuousEffect, IBlockerEffect
{
    public ThisCreatureHasBlockerEffect() : base()
    {
    }

    public bool CanBlock(ICreature blocker, ICreature attacker, IGame game)
    {
        return IsSourceOfAbility(blocker);
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureHasBlockerEffect();
    }

    public override string ToString()
    {
        return "Blocker";
    }
}