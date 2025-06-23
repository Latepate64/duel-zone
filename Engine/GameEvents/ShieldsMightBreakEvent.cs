using System.Collections.Generic;
using Interfaces;

namespace Engine.GameEvents;

public abstract class ShieldsMightBreakEvent(IEnumerable<ICard> shields) : GameEvent
{
    public IEnumerable<ICard> Shields { get; } = shields;
}
