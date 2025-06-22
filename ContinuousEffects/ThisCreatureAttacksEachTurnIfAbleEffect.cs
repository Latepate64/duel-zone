using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ThisCreatureAttacksEachTurnIfAbleEffect : ContinuousEffect, IAttacksIfAbleEffect
{
    public ThisCreatureAttacksEachTurnIfAbleEffect() : base()
    {
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return IsSourceOfAbility(creature);
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureAttacksEachTurnIfAbleEffect();
    }

    public override string ToString()
    {
        return "This creature attacks each turn if able.";
    }
}
