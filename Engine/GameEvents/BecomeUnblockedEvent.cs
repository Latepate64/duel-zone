namespace Engine.GameEvents
{
    public class BecomeUnblockedEvent : GameEvent
    {
        public BecomeUnblockedEvent(Card attacker)
        {
            Attacker = attacker;
        }

        public Card Attacker { get; }

        public override void Happen(IGame game)
        {
        }

        public override string ToString()
        {
            return $"{Attacker} was not blocked.";
        }
    }
}
