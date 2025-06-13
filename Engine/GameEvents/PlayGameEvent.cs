using System.Collections.Generic;

namespace Engine.GameEvents;

public class PlayGameEvent() : GameEventV2()
{
    int turnNumber;

    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        return [new TakeTurnEvent(++turnNumber)];
    }
}