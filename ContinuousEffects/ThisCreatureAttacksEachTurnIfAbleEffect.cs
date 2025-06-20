using Engine;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureAttacksEachTurnIfAbleEffect : ContinuousEffect, IAttacksIfAbleEffect
{
    public ThisCreatureAttacksEachTurnIfAbleEffect() : base()
    {
    }

    public bool AttacksIfAble(Creature creature, IGame game)
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
