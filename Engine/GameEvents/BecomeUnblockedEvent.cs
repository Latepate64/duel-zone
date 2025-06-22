using Interfaces;

namespace Engine.GameEvents
{
    public sealed class BecomeUnblockedEvent(ICreature attacker) : GameEvent
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
