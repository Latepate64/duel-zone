using System.Collections.Generic;

namespace Engine.GameEvents;

public class MainPhaseEvent(PlayerV2 player) : GameEventV2(player, false)
{
    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        return [new UseCardEvent(Player)];
        // TODO: Return empty if nothing can be used
    }
}