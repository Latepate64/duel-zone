using System;

namespace DuelMastersModels
{
    public abstract class DuelObject : IDisposable
    {
        public Guid Id { get; }

        protected DuelObject()
        {
            Id = Guid.NewGuid();
        }

        protected DuelObject(DuelObject duelObject, bool copyId)
        {
            Id = copyId ? duelObject.Id : Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            return obj is DuelObject duelObject && duelObject.Id == Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);
    }
}
