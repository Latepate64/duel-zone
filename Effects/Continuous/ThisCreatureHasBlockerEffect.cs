using Engine;
using Engine.ContinuousEffects;

namespace Effects.Continuous;

public class ThisCreatureHasBlockerEffect : ContinuousEffect, IBlockerEffect
{
    public ThisCreatureHasBlockerEffect() : base()
    {
    }

    public bool CanBlock(Creature blocker, Creature attacker, IGame game)
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