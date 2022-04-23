using System;

namespace Engine.Abilities
{
    public interface IAbility
    {
        Guid Id { get; }

        ICard Source { get; set; }

        /// <summary>
        /// 113.8.
        /// The controller of an activated ability on the stack is the player who activated it.
        /// The controller of a triggered ability on the stack (other than a delayed triggered ability)
        /// is the player who controlled the ability’s source when it triggered, or, if it had no controller,
        /// the player who owned the ability’s source when it triggered.
        /// </summary>
        IPlayer ControllerPlayer { get; set; }

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
}