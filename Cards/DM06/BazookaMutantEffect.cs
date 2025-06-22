using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM06;

public sealed class BazookaMutantEffect : ContinuousEffect, ICannotAttackCreaturesEffect
{
    public BazookaMutantEffect()
    {
    }

    public BazookaMutantEffect(BazookaMutantEffect effect) : base(effect)
    {
    }

    public bool CannotAttackCreature(ICreature attacker, ICreature target, IGame game)
    {
        return IsSourceOfAbility(attacker) && !target.IsBlocker;
    }

    public override IContinuousEffect Copy()
    {
        return new BazookaMutantEffect(this);
    }

    public override string ToString()
    {
        return "This creature can attack only creatures that have \"blocker.\"";
    }
}
