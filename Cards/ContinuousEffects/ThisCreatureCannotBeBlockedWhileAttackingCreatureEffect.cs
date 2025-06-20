using ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects;

public class ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect : ContinuousEffect, IUnblockableEffect
{
    public ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect()
    {
    }

    public ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect(ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect effect) : base(effect)
    {
    }

    public bool CannotBeBlocked(Creature attacker, Creature blocker, IAttackable targetOfAttack, IGame game)
    {
        return IsSourceOfAbility(attacker) && targetOfAttack is Card;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect(this);
    }

    public override string ToString()
    {
        return "While attacking a creature, this creature can't be blocked.";
    }
}
