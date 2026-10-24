namespace Interfaces;

public interface IStartGameEvent : IGameEventV2
{
    IPlayer StartingPlayer { get; }
    IPlayer OtherPlayer { get; }
}