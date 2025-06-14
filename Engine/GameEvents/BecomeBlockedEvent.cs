namespace Engine.GameEvents
{
    public class BecomeBlockedEvent(Card attacker, Card blocker) : GameEvent
    {
        public Card Attacker { get; } = attacker;
        public Card Blocker { get; } = blocker;

        public override void Happen(IGame game)
        {
        }

        public override string ToString()
        {
            return $"{Attacker} was blocked by {Blocker}.";
        }
    }
}
