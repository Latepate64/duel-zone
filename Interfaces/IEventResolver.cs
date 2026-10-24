namespace Interfaces;

public interface IEventResolver<T, U> where T : IGameEvent where U : IGameEvent
{
    IEnumerable<U> Resolve(IGameState state, IPlayer applier, T gameEvent);
}
