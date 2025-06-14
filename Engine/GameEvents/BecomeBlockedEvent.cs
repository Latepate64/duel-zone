namespace Engine.GameEvents
{
    public class BecomeBlockedEvent : GameEvent
    {
        public BecomeBlockedEvent(Card attacker, Card blocker)
        {
            Attacker = attacker;
            Blocker = blocker;
        }

        public Card Attacker { get; }
        public Card Blocker { get; }

        public override void Happen(IGame game)
        {
        }

        public override string ToString()
        {
            return $"{Attacker} was blocked by {Blocker}.";
        }
    }
}
