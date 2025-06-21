namespace Engine.GameEvents
{
    public class BecomeUnblockedEvent(ICreature attacker) : GameEvent
    {
        public ICreature Attacker { get; } = attacker;

        public override void Happen(IGame game)
        {
        }

        public override string ToString()
        {
            return $"{Attacker} was not blocked.";
        }
    }
}
