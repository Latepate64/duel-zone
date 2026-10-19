namespace Interfaces;

/// <summary>
/// An ability can be one of three things: An ability can be a characteristic an
/// object has that lets it affect the game; An ability can be something that a
/// player has that changes how the game affects the player.; An ability can be
/// an activated or triggered ability on the stack.
/// </summary>
public interface IAbility
{
    ICard Source { get; set; }

    /// <summary>
    /// 113.8.
    /// The controller of an activated ability on the stack is the player who activated it.
    /// The controller of a triggered ability on the stack (other than a delayed triggered ability)
    /// is the player who controlled the ability’s source when it triggered, or,
    /// if it had no controller, the player who owned the ability’s source when it triggered.
    /// </summary>
    IPlayer Controller { get; set; }

    IAbility Copy();
}
