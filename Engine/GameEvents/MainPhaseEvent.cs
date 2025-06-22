using System.Collections.Generic;
using Interfaces;

namespace Engine.GameEvents;

public sealed class MainPhaseEvent(IPlayerV2 player) : GameEventV2(player, false)
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