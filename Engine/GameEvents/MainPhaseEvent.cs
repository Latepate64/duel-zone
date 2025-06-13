using System.Collections.Generic;

namespace Engine.GameEvents;

public class MainPhaseEvent : GameEventV2
{
    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        return [new UseCardEvent(state.ActivePlayer)];
        // TODO: Return empty if nothing can be used
    }
}