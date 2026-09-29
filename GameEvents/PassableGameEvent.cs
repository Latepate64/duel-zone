using Interfaces;

namespace GameEvents;

public abstract class PassableGameEvent : GameEventV2, IPassableGameEvent
{
    protected PassableGameEvent(IPlayerV2 player) : base(player)
    {
    }

    protected PassableGameEvent(IPassableGameEvent gameEvent) : base(gameEvent)
    {
    }

    public abstract void Validate(IPassableGameEvent gameEvent);
}