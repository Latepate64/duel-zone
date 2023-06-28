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
        IPlayer Controller { get; set; }
        IGame Game { get; }

        IAbility Copy();

        string ToString();
    }
}