using Interfaces;

namespace ContinuousEffects.Replacement;

public abstract class WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : DestructionReplacementEffect
{
    protected WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect() : base()
    {
    }

    protected WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }
}
