using System;
using Engine.GameEvents;

namespace Engine;

public class IllegalActionException(GameEventV2 gameEvent, string message) : Exception(message)
{
    public GameEventV2 PlayerAction { get; } = gameEvent;
}