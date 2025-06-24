using Interfaces;

namespace GameEvents;

public sealed class IllegalActionException(IGameEventV2 gameEvent, IllegalActionType type) : Exception
{
    public IGameEventV2 GameEvent { get; } = gameEvent;
    public IllegalActionType Type { get; } = type;

    internal static T ThrowIfNotOfType<T>(IGameEventV2 gameEvent)
    {
        if (gameEvent is not T expected)
        {
            throw new IllegalActionException(gameEvent, IllegalActionType.UnexpectedType);
        }
        return expected;
    }

    internal static void ThrowIf(IGameEventV2 gameEvent, bool condition, IllegalActionType type)
    {
        if (condition)
        {
            throw new IllegalActionException(gameEvent, type);
        }
    }
}
