using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AttacksIfAble;

public sealed class EachCreatureAttacksIfAbleEffect : ContinuousEffect, IAttacksIfAbleEffect
{
    public EachCreatureAttacksIfAbleEffect() : base()
    {
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new EachCreatureAttacksIfAbleEffect();
    }
}
