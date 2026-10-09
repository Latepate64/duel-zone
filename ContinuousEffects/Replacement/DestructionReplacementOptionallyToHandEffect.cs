using Interfaces;

namespace ContinuousEffects.Replacement;

public abstract class DestructionReplacementOptionallyToHandEffect : DestructionReplacementEffect
{
    public DestructionReplacementOptionallyToHandEffect() : base()
    {
    }

    public DestructionReplacementOptionallyToHandEffect(DestructionReplacementOptionallyToHandEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }
}
