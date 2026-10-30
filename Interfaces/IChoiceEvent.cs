namespace Interfaces;

public interface IChoiceEvent<T> : IGameEvent
{
    T[] Chosen { get; }
}
