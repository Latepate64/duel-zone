using Interfaces;

namespace GameEvents;

public sealed class ChargePhaseEvent : GameEventV2
{
    bool shouldEnd;

    public ChargePhaseEvent(IPlayerV2 player) : base(player)
    {
    }

    ChargePhaseEvent(ChargePhaseEvent gameEvent) : base(gameEvent)
    {
        shouldEnd = gameEvent.shouldEnd;
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        if (!shouldEnd && Player.Hand.HasCards)
        {
            shouldEnd = true;
            return [new ChargeEvent(Player)];
        }
        shouldEnd = true;
        return [];
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not ChargePhaseEvent e) return false;
        if (e.shouldEnd != shouldEnd) return false;
        return true;
    }

    public override IGameEventV2 Copy()
    {
        return new ChargePhaseEvent(this);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), shouldEnd.GetHashCode());
    }
}