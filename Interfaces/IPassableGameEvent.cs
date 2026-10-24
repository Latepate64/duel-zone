namespace Interfaces;

public interface IPassableGameEvent : IGameEvent
{
    IPlayer Player { get; }
    void Validate(IPassableGameEvent gameEvent);
}
