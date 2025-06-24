using Interfaces;

namespace GameEvents;

public sealed class DrawPhaseEvent(IPlayerV2 player) : GameEventV2(player, false)
{
    bool shouldEnd;

    public override IEnumerable<GameEventV2> Happen(IGameState state)
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