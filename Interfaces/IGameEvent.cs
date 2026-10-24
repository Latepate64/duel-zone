namespace Interfaces;

public interface IGameEvent
{
    /// <summary>
    /// Copies the event.
    /// </summary>
    /// <returns>A copy of the event.</returns>
    IGameEvent Copy();
}
