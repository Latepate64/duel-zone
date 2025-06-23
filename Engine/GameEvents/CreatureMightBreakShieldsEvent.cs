using Interfaces;

namespace Engine.GameEvents;

public abstract class CreatureMightBreakShieldsEvent(ICreature attacker, int breakAmount) : GameEvent
{
    public ICreature Attacker { get; } = attacker;
    public int BreakAmount { get; } = breakAmount;
}
