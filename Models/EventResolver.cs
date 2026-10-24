using Interfaces;

namespace Models;

public abstract class EventResolver<T> where T : IGameEvent
{
    public abstract IEnumerable<IGameEvent> Resolve(
        IGameState state, IPlayer applier, T gameEvent);
}
