namespace Interfaces;

public interface IStartGameEvent : IGameEvent
{
    IPlayer StartingPlayer { get; }
    IPlayer OtherPlayer { get; }
}