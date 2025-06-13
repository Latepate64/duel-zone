using System.Collections.Generic;

namespace Engine.GameEvents;

public class PassAction(PlayerV2 player) : PlayerAction(player, false)
{
    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        return [];
    }
}
