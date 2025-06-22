using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class SkipBattleAfterBecomesBlockedEffect : ContinuousEffect, ISkipBattleAfterBlockEffect
{
    public SkipBattleAfterBecomesBlockedEffect()
    {
    }

    public SkipBattleAfterBecomesBlockedEffect(SkipBattleAfterBecomesBlockedEffect effect) : base(effect)
    {
    }

    public bool Applies(ICreature attacker, ICreature blocker, IGame game)
    {
        return attacker == Source;
    }

    public override IContinuousEffect Copy()
    {
        return new SkipBattleAfterBecomesBlockedEffect(this);
    }

    public override string ToString()
    {
        return "Whenever this creature becomes blocked, no battle happens.";
    }
}
