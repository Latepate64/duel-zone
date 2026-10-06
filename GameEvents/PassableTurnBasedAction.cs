using Interfaces;

namespace GameEvents;

public abstract class PassableTurnBasedAction : TurnBasedAction,
    IPassableGameEvent
{
    protected PassableTurnBasedAction(IPlayerV2 player) : base(player)
    {
    }

    protected PassableTurnBasedAction(PassableTurnBasedAction gameEvent) : base(
        gameEvent)
    {
    }

    public abstract void Validate(IPassableGameEvent gameEvent);
}