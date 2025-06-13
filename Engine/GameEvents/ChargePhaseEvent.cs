using System.Collections.Generic;

namespace Engine.GameEvents;

public class ChargePhaseEvent(PlayerV2 player) : GameEventV2(player, false)
{
    bool prompted;

    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        if (!prompted)
        {
            prompted = true;
            return [new ChargeEvent(Player, true)];
        }
        return [];
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj) && obj is ChargePhaseEvent e && e.prompted == prompted;
    }
}