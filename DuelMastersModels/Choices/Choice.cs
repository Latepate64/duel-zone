using System;

namespace DuelMastersModels.Choices
{
    /// <summary>
    /// Represents a choice a player can make.
    /// </summary>
    public abstract class Choice
    {
        /// <summary>
        /// Player who makes the choice.
        /// </summary>
        public Guid Player { get; private set; }

        protected Choice(Guid player)
        {
            Player = player;
        }
    }

    public abstract class Decision
    {
    }
}