using Interfaces;

namespace Models;

public abstract class EventResolver<T, U> : IEventResolver<T, U> where T : IGameEvent where U : IGameEvent
{
    public bool Finished { get; protected set; }

    public abstract IEnumerable<U> Resolve(IGameState state, IPlayer applier, T gameEvent);
}
