using System;

namespace Engine
{
    public abstract class CardFilter : IDisposable
    {
        protected CardFilter() { }

        public abstract bool Applies(ICard card, IGame game, IPlayer player);

        public abstract CardFilter Copy();

        protected virtual void Dispose(bool disposing) { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract override string ToString();
    }
}