using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AttacksIfAble;

public sealed class ThisCreatureAttacksIfAbleEffect : ContinuousEffect, IAttacksIfAbleEffect
{
    public ThisCreatureAttacksIfAbleEffect() : base()
    {
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return IsSourceOfAbility(creature);
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureAttacksIfAbleEffect();
    }
}
