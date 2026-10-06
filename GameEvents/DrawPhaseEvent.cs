using Interfaces;

namespace GameEvents;

public sealed class DrawPhaseEvent : TurnBasedAction
{
    bool shouldEnd;

    public DrawPhaseEvent(IPlayerV2 player) : base(player)
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

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not DrawPhaseEvent e) return false;
        if (shouldEnd != e.shouldEnd) return false;
        return true;
    }

    public override IGameEventV2 Copy()
    {
        return new DrawPhaseEvent(this);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), shouldEnd.GetHashCode());
    }
}