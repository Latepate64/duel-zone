namespace Engine.GameEvents
{
    public class BecomeBlockedEvent(Creature attacker, Creature blocker) : GameEvent
    {
        public Creature Attacker { get; } = attacker;
        public Creature Blocker { get; } = blocker;

        public override void Happen(IGame game)
        {
        }

        public override string ToString()
        {
            return $"{Attacker} was blocked by {Blocker}.";
        }
    }
}
