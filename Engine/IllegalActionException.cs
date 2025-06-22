using System;
using Engine.GameEvents;

namespace Engine;

public sealed class IllegalActionException(GameEventV2 gameEvent, IllegalActionType type) : Exception
{
    public GameEventV2 GameEvent { get; } = gameEvent;
    public IllegalActionType Type { get; } = type;

    internal static T ThrowIfNotOfType<T>(GameEventV2 gameEvent)
    {
        if (gameEvent is not T expected)
        {
            throw new IllegalActionException(gameEvent, IllegalActionType.UnexpectedType);
        }
        return expected;
    }

    internal static void ThrowIf(GameEventV2 gameEvent, bool condition, IllegalActionType type)
    {
        if (condition)
        {
            throw new IllegalActionException(gameEvent, type);
        }
    }
}
