namespace Engine.GameEvents
{
    public class BecomeUnblockedEvent(Creature attacker) : GameEvent
    {
        public Creature Attacker { get; } = attacker;

        public override void Happen(IGame game)
        {
        }

        public override string ToString()
        {
            return $"{Attacker} was not blocked.";
        }
    }
}
