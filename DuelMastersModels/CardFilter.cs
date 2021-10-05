using System;

namespace DuelMastersModels
{
    public abstract class CardFilter : IDisposable
    {
        public Guid Source { get; set; }

        public Guid Owner { get; set; }

        protected CardFilter() { }

        protected CardFilter(CardFilter filter)
        {
            Source = filter.Source;
            Owner = filter.Owner;
        }

        public abstract bool Applies(Card card, Duel duel);

        public abstract CardFilter Copy();

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
