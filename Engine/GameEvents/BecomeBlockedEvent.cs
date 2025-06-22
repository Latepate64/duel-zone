using Interfaces;

namespace Engine.GameEvents
{
    public sealed class BecomeBlockedEvent(ICreature attacker, ICreature blocker) : GameEvent
    {
        public ICreature Attacker { get; } = attacker;
        public ICreature Blocker { get; } = blocker;

        public override void Happen(IGame game)
        {
        }

        public override string ToString()
        {
            return $"{Attacker} was blocked by {Blocker}.";
        }
    }
}
