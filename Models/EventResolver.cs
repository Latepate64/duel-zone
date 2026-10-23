using Interfaces;

namespace Models;

public abstract class EventResolver<T> where T : IGameEventV3
{
    public abstract IEnumerable<IGameEventV3> Resolve(
        IGameState state, IPlayerV2 applier, T effect);
}
