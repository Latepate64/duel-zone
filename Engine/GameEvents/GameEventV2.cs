using System.Collections.Generic;

namespace Engine.GameEvents;

public abstract class GameEventV2
{
    protected int index;

    /// <param name="state">The current state of the game.</param>
    /// <returns>Events that would happen during the event.</returns>
    internal abstract IEnumerable<GameEventV2> Happen(GameState state);

    public override bool Equals(object obj)
    {
        return obj is GameEventV2 e
            && index == e.index;
    }
}