using Interfaces;

namespace ContinuousEffects;

public abstract class WhenOneOfYourShieldsWouldBeBrokenEffect : ReplacementEffect
{
    protected WhenOneOfYourShieldsWouldBeBrokenEffect()
    {
    }

    protected WhenOneOfYourShieldsWouldBeBrokenEffect(WhenOneOfYourShieldsWouldBeBrokenEffect effect) : base(effect)
    {
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }
}
