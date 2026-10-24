namespace Interfaces;

public interface IPassableGameEvent : IGameEventV2
{
    IPlayer Player { get; }
    void Validate(IPassableGameEvent gameEvent);
}
