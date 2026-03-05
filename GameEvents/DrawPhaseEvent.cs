using Interfaces;

namespace GameEvents;

public sealed class DrawPhaseEvent : GameEventV2
{
    bool shouldEnd;

    public DrawPhaseEvent(IPlayerV2 player) : base(player, false)
    {
    }

    DrawPhaseEvent(DrawPhaseEvent gameEvent) : base(gameEvent)
    {
        shouldEnd = gameEvent.shouldEnd;
    }

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

    public override IGameEventV2 Copy()
    {
        return new DrawPhaseEvent(this);
    }
}