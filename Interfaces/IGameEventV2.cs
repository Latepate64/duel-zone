namespace Interfaces;

/// <summary>
/// 700.1. Anything that happens in a game is an event.
/// </summary>
public interface IGameEventV2
{
    IPlayerV2 Player { get; }

    /// <summary>
    /// Processes the event based on the current state of the game.
    /// </summary>
    /// <param name="state">Current state of the game.</param>
    /// <returns>New events which the event produces,
    /// null if the event has finished happening.</returns>
    IEnumerable<IGameEventV2> Happen(IGameState state);

    /// <summary>
    /// Copies the event.
    /// </summary>
    /// <returns>A copy of the event.</returns>
    IGameEventV2 Copy();
}
