using System.Collections.Generic;
using Interfaces;

namespace Engine.GameEvents;

public abstract class GameEventV2(IPlayerV2 player, bool passable)
{
    public IPlayerV2 Player { get; } = player;
    public bool Passable { get; } = passable;

    /// <param name="state">The current state of the game.</param>
    /// <returns>Events that would happen during the event. If none, the event has completely happened.</returns>
    internal abstract IEnumerable<GameEventV2> Happen(GameState state);

    internal virtual void Validate(GameEventV2 gameEvent)
    {
        throw new IllegalActionException(gameEvent, IllegalActionType.Unknown);
    }

    public override bool Equals(object obj)
    {
        return obj is GameEventV2 e
            && Player == e.Player
            && Passable == e.Passable;
    }
}