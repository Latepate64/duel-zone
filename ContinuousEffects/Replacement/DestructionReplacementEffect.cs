using Interfaces;

namespace ContinuousEffects.Replacement;

public abstract class DestructionReplacementEffect : ReplacementEffect
{
    protected DestructionReplacementEffect() : base()
    {
    }

    protected DestructionReplacementEffect(DestructionReplacementEffect effect) : base(effect)
    {
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    protected abstract bool Applies(ICreature creature, IGame game);
}
