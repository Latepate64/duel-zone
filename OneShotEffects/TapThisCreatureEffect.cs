using Interfaces;

namespace OneShotEffects;

public sealed class TapThisCreatureEffect : OneShotEffect
{
    public TapThisCreatureEffect() : base()
    {
    }

    public TapThisCreatureEffect(TapThisCreatureEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new TapThisCreatureEffect(this);
    }

    public override void Apply(IGame game)
    {
        Controller.Tap(game, Source);
    }
}
