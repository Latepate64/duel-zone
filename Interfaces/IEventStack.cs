namespace Interfaces;

public interface IEventStack
{
    bool IsEmpty { get; }
    void Push(params IGameEventV2[] gameEvents);
    public IGameEventV2[] Pop();
    IEnumerable<IGameEventV2> Happen(IGameState state);
}
