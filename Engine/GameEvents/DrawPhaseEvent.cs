using System.Collections.Generic;

namespace Engine.GameEvents;

public class DrawPhaseEvent : GameEventV2
{
    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        if (index == 0)
        {
            ++index;
            return [new MoveTopCardOfDeckEvent(state.ActivePlayer, ZoneType.Hand)];
        }
        return [];
    }
}