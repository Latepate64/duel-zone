using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM09;

public sealed class GabzagulWarlordOfPainEffect : ContinuousEffect, IAttacksIfAbleEffect
{
    public GabzagulWarlordOfPainEffect() : base()
    {
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new GabzagulWarlordOfPainEffect();
    }

    public override string ToString()
    {
        return "Each creature attacks each turn if able.";
    }
}
