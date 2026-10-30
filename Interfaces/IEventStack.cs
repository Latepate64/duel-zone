namespace Interfaces;

public interface IEventStack<T, U> where T : IGameEvent where U : IGameEvent
{
    bool IsEmpty { get; }
    void Push(params T[] gameEvents);
    public T[] Pop();
    IEnumerable<U> Happen(IGameState state);
    IEventStack<T, U> Copy();
    void SetChoice(IChoiceEvent<ICard> choice);
}
