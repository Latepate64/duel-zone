using System;

namespace DuelMastersModels.GameEvents
{
    public abstract class GameEvent
    {
        protected GameEvent()
        {
            Id = Guid.NewGuid();
        }

        protected GameEvent(GameEvent e)
        {
            Id = e.Id;
        }

        public Guid Id { get; }

        public virtual void Apply(Duel duel)
        {
        }

        public abstract string ToString(Duel duel);

        public virtual GameEvent Copy() { return null; }
    }
}
