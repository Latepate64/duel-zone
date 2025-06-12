using System;
using Engine.GameEvents;

namespace Engine;

public class IllegalActionException(PlayerAction playerAction) : Exception
{
    public PlayerAction PlayerAction { get; } = playerAction;
}