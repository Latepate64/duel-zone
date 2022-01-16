using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Abilities
{
    public abstract class Resolvable : IDisposable
    {
        public Guid Source { get; set; }
        public Guid Controller { get; set; }

        protected Resolvable() { }

        protected Resolvable(Resolvable resolvable)
        {
            Controller = resolvable.Controller;
            Source = resolvable.Source;
        }

        public abstract void Resolve(Duel duel, Decision decision);

        public abstract Resolvable Copy();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
