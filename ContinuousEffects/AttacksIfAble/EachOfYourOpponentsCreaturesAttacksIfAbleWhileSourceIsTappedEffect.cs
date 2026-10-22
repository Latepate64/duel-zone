using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AttacksIfAble;

public sealed class EachOfYourOpponentsCreaturesAttacksIfAbleWhileSourceIsTappedEffect
    : EachOfYourOpponentsCreaturesAttacksIfAbleEffect
{
    public EachOfYourOpponentsCreaturesAttacksIfAbleWhileSourceIsTappedEffect() : base()
    {
    }

    private EachOfYourOpponentsCreaturesAttacksIfAbleWhileSourceIsTappedEffect(
        EachOfYourOpponentsCreaturesAttacksIfAbleWhileSourceIsTappedEffect effect) : base(effect)
    {
    }

    public override bool AttacksIfAble(ICreature creature, IGame game)
    {
        if (!base.AttacksIfAble(creature, game)) return false;
        return Source!.Tapped;
    }

    public override IContinuousEffect Copy()
    {
        return new EachOfYourOpponentsCreaturesAttacksIfAbleWhileSourceIsTappedEffect(this);
    }
}
