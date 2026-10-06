namespace Interfaces;

public interface ITurnBasedAction : IGameEventV2
{
    IPlayerV2 Player { get; }
}