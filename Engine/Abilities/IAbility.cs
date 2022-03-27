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

        IAbility Copy();

        /// <summary>
        /// Returns the player who controls the ability.
        /// Note that it should be checked that the player actually
        /// exists as it is possible they have left the game.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        IPlayer GetController(IGame game);

        /// <summary>
        /// Returns the opponent of the player who controls the ability.
        /// Note that it should be checked that the player actually
        /// exists as it is possible they have left the game.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        IPlayer GetOpponent(IGame game);

        string ToString();
    }
}