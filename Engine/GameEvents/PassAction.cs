using System.Collections.Generic;

namespace Engine.GameEvents;

public class PassAction(IPlayerV2 player) : GameEventV2(player, false)
{
    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        return [];
    }
}
