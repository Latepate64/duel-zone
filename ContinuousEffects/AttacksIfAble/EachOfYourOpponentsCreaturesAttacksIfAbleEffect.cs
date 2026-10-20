using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AttacksIfAble;

public class EachOfYourOpponentsCreaturesAttacksIfAbleEffect : ContinuousEffect,
    IAttacksIfAbleEffect
{
    public EachOfYourOpponentsCreaturesAttacksIfAbleEffect()
    {
    }

    protected EachOfYourOpponentsCreaturesAttacksIfAbleEffect(
        EachOfYourOpponentsCreaturesAttacksIfAbleEffect effect) : base(effect)
    {
    }

    public virtual bool AttacksIfAble(ICreature creature, IGame game)
    {
        return creature.OwnerV2.Equals(Applier.Opponent);
    }

    public override IContinuousEffect Copy()
    {
        return new EachOfYourOpponentsCreaturesAttacksIfAbleEffect(this);
    }
}
