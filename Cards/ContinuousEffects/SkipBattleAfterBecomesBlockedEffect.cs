using ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects;

public class SkipBattleAfterBecomesBlockedEffect : ContinuousEffect, ISkipBattleAfterBlockEffect
{
    public SkipBattleAfterBecomesBlockedEffect()
    {
    }

    public SkipBattleAfterBecomesBlockedEffect(SkipBattleAfterBecomesBlockedEffect effect) : base(effect)
    {
    }

    public bool Applies(Card attacker, Card blocker, IGame game)
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
