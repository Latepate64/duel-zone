using System;

namespace DuelMastersModels
{
    public abstract class DuelObject
    {
        public Guid Id { get; }

        protected DuelObject()
        {
            Id = Guid.NewGuid();
        }

        protected DuelObject(DuelObject duelObject)
        {
            Id = duelObject.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is DuelObject duelObject && duelObject.Id == Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
