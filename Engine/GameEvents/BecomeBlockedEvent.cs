using System;

namespace Engine.GameEvents
{
    public class BecomeBlockedEvent : GameEvent
    {
        public BecomeBlockedEvent(ICard attacker, ICard blocker)
        {
            Attacker = attacker;
            Blocker = blocker;
        }

        public ICard Attacker { get; }
        public ICard Blocker { get; }

        public override void Happen(IGame game)
        {
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
