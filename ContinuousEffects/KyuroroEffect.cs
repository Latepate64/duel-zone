using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class KyuroroEffect : ReplacementEffect
{
    public KyuroroEffect()
    {
    }

    public KyuroroEffect(KyuroroEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IContinuousEffect Copy()
    {
        return new KyuroroEffect(this);
    }

    public override string ToString()
    {
        return "Whenever an opponent's creature would break a shield, you choose the shield instead of your opponent.";
    }
}
