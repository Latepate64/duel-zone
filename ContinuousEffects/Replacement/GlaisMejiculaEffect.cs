using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Replacement;

public sealed class GlaisMejiculaEffect : WhenOneOfYourShieldsWouldBeBrokenEffect
{
    public GlaisMejiculaEffect()
    {
    }

    public GlaisMejiculaEffect(WhenOneOfYourShieldsWouldBeBrokenEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IContinuousEffect Copy()
    {
        return new GlaisMejiculaEffect(this);
    }

    public override string ToString()
    {
        return "Whenever one of your shields would be broken, you may discard 2 cards from your hand instead.";
    }
}
