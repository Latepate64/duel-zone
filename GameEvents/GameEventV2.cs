using Interfaces;

namespace GameEvents;

/// <summary>
/// 700.1. Anything that happens in a game is an event.
/// </summary>
public abstract class GameEventV2 : IGameEventV2
{
    /// <summary>
    /// Processes the event based on the current state of the game.
    /// </summary>
    /// <param name="state">The current state of the game.</param>
    /// <returns>Events that would happen during the event.
    /// If none, the event has completely happened.</returns>
    public abstract IEnumerable<IGameEventV2> Happen(IGameState state);

    /// <summary>
    /// Copies the event.
    /// </summary>
    /// <returns>A copy of the event.</returns>
    public abstract IGameEventV2 Copy();
}