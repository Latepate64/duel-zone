using System.Collections.Generic;

namespace Engine.GameEvents;

public class DrawPhaseEvent(PlayerV2 player) : GameEventV2(player, false)
{
    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        if (index == 0)
        {
            ++index;
            return [new MoveTopCardOfDeckEvent(Player, ZoneType.Hand)];
        }
        return [];
    }
}