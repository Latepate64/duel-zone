namespace Engine.GameEvents
{
    public class BecomeUnblockedEvent : GameEvent
    {
        public BecomeUnblockedEvent(ICard attacker)
        {
            Attacker = attacker;
        }

        public ICard Attacker { get; }

        public override void Happen(IGame game)
        {
        }

        public override string ToString()
        {
            return $"{Attacker} was not blocked.";
        }
    }
}
