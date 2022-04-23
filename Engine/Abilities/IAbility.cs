using System;

namespace Engine.Abilities
{
    public interface IAbility
    {
        Guid Id { get; }

        /// <summary>
        /// 113.8.
        /// The controller of an activated ability on the stack is the player who activated it.
        /// The controller of a triggered ability on the stack (other than a delayed triggered ability)
        /// is the player who controlled the ability’s source when it triggered, or, if it had no controller,
        /// the player who owned the ability’s source when it triggered.
        /// </summary>
        Guid Controller { get; set; }

        /// <summary>
        /// 113.7.
        /// The source of an ability is the object that generated it.
        /// </summary>
        Guid Source { get; set; }
        ICard SourceCard { get; set; }

        IAbility Copy();

        /// <summary>
        /// Player who controls the ability.
        /// </summary>
        /// <param name="game"></param>
        /// <exception cref="PlayerNotInGameException"></exception>
        /// <returns>Player who controls the ability.</returns>
        IPlayer GetController(IGame game);

        /// <summary>
        /// Opponent of the player who controls the ability.
        /// </summary>
        /// <param name="game"></param>
        /// <exception cref="PlayerNotInGameException"></exception>
        /// <returns>Opponent of the player who controls the ability.</returns>
        IPlayer GetOpponent(IGame game);

        string ToString();
    }
}