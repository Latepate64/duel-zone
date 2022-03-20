using System;

namespace Common.GameEvents
{
    public abstract class GameEvent : IGameEvent
    {
        protected GameEvent()
        {
            Id = Guid.NewGuid();
        }

        protected GameEvent(GameEvent e)
        {
            Id = e.Id;
        }

        public Guid Id { get; set; }

        public virtual IGameEvent Copy() { return null; }

        public override abstract string ToString();
    }
}
