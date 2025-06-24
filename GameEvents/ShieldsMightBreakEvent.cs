using Interfaces;

namespace GameEvents;

public abstract class ShieldsMightBreakEvent(IEnumerable<ICard> shields) : GameEvent
{
    public IEnumerable<ICard> Shields { get; } = shields;
}
