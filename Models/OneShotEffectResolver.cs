using Interfaces;

namespace Models;

public abstract class OneShotEffectResolver<T> where T : OneShotEffect
{
    public abstract IEnumerable<OneShotEffect> Resolve(
        IGameState state, IPlayerV2 applier, T effect);
}
