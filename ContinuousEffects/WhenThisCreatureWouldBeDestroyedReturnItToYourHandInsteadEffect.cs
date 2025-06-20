using Engine;

namespace ContinuousEffects;

public class WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect : WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect
{
    public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect() : base()
    {
    }

    public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect effect) : base(effect)
    {
    }

    public override ContinuousEffect Copy()
    {
        return new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(this);
    }

    public override string ToString()
    {
        return "When this creature would be destroyed, return it to your hand instead.";
    }

    protected override bool Applies(Creature card, IGame game)
    {
        return IsSourceOfAbility(card);
    }
}
