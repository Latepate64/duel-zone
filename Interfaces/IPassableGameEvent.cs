namespace Interfaces;

public interface IPassableGameEvent : IGameEventV2
{
    void Validate(IPassableGameEvent gameEvent);
}