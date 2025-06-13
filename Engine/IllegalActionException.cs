using System;
using Engine.GameEvents;

namespace Engine;

public class IllegalActionException(PlayerAction playerAction, string message) : Exception(message)
{
    public PlayerAction PlayerAction { get; } = playerAction;
}