using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ChekiculEffect : ContinuousEffect, ISkipBattleAfterBlockEffect
{
    public ChekiculEffect()
    {
    }

    public ChekiculEffect(ChekiculEffect effect) : base(effect)
    {
    }

    public bool Applies(ICreature attacker, ICreature blocker, IGame game)
    {
        return blocker == Source;
    }

    public override IContinuousEffect Copy()
    {
        return new ChekiculEffect(this);
    }

    public override string ToString()
    {
        return "Whenever this creature blocks, no battle happens.";
    }
}
