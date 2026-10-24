using Interfaces;

namespace Models;

public abstract class EventResolver<T> where T : IGameEvent
{
    public abstract IEnumerable<IGameEvent> Resolve(
        IGameState state, IPlayerV2 applier, T gameEvent);
}
