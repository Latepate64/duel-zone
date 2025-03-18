using System;

namespace Engine.Abilities;

/// <summary>
/// 113.1.
/// An ability can be one of three things: An ability can be a characteristic an
/// object has that lets it affect the game; An ability can be something that a
/// player has that changes how the game affects the player.; An ability can be
/// an activated or triggered ability on the stack.
/// </summary>
public interface IAbility
{
    Guid Id { get; }

    /// <summary>
    /// 113.7. The card that generated this ability.
    /// </summary>
    ICard Source { get; set; }

    /// <summary>
    /// 113.8.
    /// The controller of an activated ability on the stack is the player who activated it.
    /// The controller of a triggered ability on the stack (other than a delayed triggered ability)
    /// is the player who controlled the ability’s source when it triggered, or, if it had no controller,
    /// the player who owned the ability’s source when it triggered.
    /// </summary>
    IPlayer Controller { get; set; }

    IAbility Copy();

    /// <summary>
    /// Opponent of the player who controls the ability.
    /// </summary>
    /// <param name="game"></param>
    /// <exception cref="PlayerNotInGameException"></exception>
    /// <returns>Opponent of the player who controls the ability.</returns>
    IPlayer GetOpponent(IGame game);

    string ToString();
}