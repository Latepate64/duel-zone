using System.Collections.Generic;
using Interfaces;

namespace Engine.GameEvents;

public sealed class DrawPhaseEvent(IPlayerV2 player) : GameEventV2(player, false)
{
    bool shouldEnd;

    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        if (!shouldEnd)
        {
            shouldEnd = true;
            return [new MoveTopCardOfDeckEvent(Player, ZoneType.Hand)];
        }
        return [];
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj) && obj is DrawPhaseEvent e && shouldEnd == e.shouldEnd;
    }
}