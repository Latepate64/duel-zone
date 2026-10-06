namespace Interfaces;

public interface IStartGameEvent : IGameEventV2
{
    IPlayerV2 StartingPlayer { get; }
    IPlayerV2 OtherPlayer { get; }
}