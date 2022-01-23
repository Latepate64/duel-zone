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

        public virtual void Apply(Game game)
        {
        }

        public virtual GameEvent Copy() { return null; }

        public string Text { get; protected set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
