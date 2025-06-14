namespace Engine.GameEvents
{
    public class BecomeUnblockedEvent(Card attacker) : GameEvent
    {
        public Card Attacker { get; } = attacker;

        public override void Happen(IGame game)
        {
        }

        public override string ToString()
        {
            return $"{Attacker} was not blocked.";
        }
    }
}
