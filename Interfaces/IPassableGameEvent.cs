namespace Interfaces;

public interface IPassableGameEvent : IGameEventV2
{
    IPlayerV2 Player { get; }
    void Validate(IPassableGameEvent gameEvent);
}
