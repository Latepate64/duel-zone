using System.Collections.Generic;

namespace Engine.GameEvents;

public class MainPhaseEvent(PlayerV2 player) : GameEventV2(player, false)
{
    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        if (Player.Hand.HasCards)
        {
            // TODO: Check if any card can actually be used?
            return [new UseCardEvent(Player)];
        }
        return [];
    }
}