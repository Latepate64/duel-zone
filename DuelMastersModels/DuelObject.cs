using System;

namespace DuelMastersModels
{
    public abstract class DuelObject : IDisposable
    {
        public Guid Id { get; }

        /// <summary>
        /// 109.5. The words “you” and “your” on an object refer to the object’s controller, its would-be controller (if a player is attempting to play, cast, or activate it), or its owner (if it has no controller).
        /// </summary>
        public Guid Controller { get; set; }

        /// <summary>
        /// 109.5. The words “you” and “your” on an object refer to the object’s controller, its would-be controller (if a player is attempting to play, cast, or activate it), or its owner (if it has no controller).
        /// </summary>
        public Guid Owner { get; set; }

        protected DuelObject()
        {
            Id = Guid.NewGuid();
        }

        protected DuelObject(DuelObject duelObject, bool copyId)
        {
            Id = copyId ? duelObject.Id : Guid.NewGuid();
            Controller = duelObject.Controller;
            Owner = duelObject.Owner;
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
