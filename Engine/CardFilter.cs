using System;

namespace Engine
{
    public abstract class CardFilter : IDisposable
    {
        protected CardFilter() { }

        public abstract bool Applies(Card card, Game game, Player player);

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