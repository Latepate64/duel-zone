using System;

namespace Engine.Choices
{
    /// <summary>
    /// Represents a choice a player can make.
    /// </summary>
    public abstract class Choice : IDisposable
    {
        /// <summary>
        /// Player who makes the choice.
        /// </summary>
        public Guid Player { get; private set; }

        protected Choice(Guid player)
        {
            Player = player;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);
    }

    public abstract class Decision : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);
    }
}