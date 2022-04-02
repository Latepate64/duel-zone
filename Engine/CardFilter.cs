using System;

namespace Engine
{
    public abstract class CardFilter : ICardFilter
    {
        protected CardFilter() { }

        public abstract bool Applies(ICard card, IGame game, IPlayer player);

        public abstract ICardFilter Copy();

        protected virtual void Dispose(bool disposing) { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}