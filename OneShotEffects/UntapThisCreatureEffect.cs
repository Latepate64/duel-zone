using Interfaces;

namespace OneShotEffects;

public sealed class UntapThisCreatureEffect : OneShotEffect
{
    public UntapThisCreatureEffect() : base() { }

    public UntapThisCreatureEffect(
        UntapThisCreatureEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        throw new NotImplementedException();
    }

    public override IOneShotEffect Copy()
    {
        return new UntapThisCreatureEffect(this);
    }
}
