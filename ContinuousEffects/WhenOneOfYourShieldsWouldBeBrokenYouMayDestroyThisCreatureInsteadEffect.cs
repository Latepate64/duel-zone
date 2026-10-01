using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect : WhenOneOfYourShieldsWouldBeBrokenEffect
{
    public WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect()
    {
    }

    public WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect(WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IContinuousEffect Copy()
    {
        return new WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect(this);
    }

    public override string ToString()
    {
        return "When one of your shields would be broken, you may destroy this creature instead.";
    }
}
