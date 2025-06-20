using Engine;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureCannotBeBlockedEffect : ContinuousEffect, IUnblockableEffect
{
    public ThisCreatureCannotBeBlockedEffect(ThisCreatureCannotBeBlockedEffect effect) : base(effect)
    {
    }

    public ThisCreatureCannotBeBlockedEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeBlockedEffect(this);
    }

    public override string ToString()
    {
        return "This creature can't be blocked.";
    }

    public bool CannotBeBlocked(Creature attacker, Creature blocker, IAttackable targetOfAttack, IGame game)
    {
        return IsSourceOfAbility(attacker);
    }
}
