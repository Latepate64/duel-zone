using Interfaces;

namespace GameEvents;

public sealed class ChargePhaseEvent : GameEventV2
{
    bool shouldEnd;

    public ChargePhaseEvent(IPlayerV2 player) : base(player, false)
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
            return [new ChargeEvent(Player, true)];
        }
        return [];
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj) && obj is ChargePhaseEvent e && e.shouldEnd == shouldEnd;
    }

    public override IGameEventV2 Copy()
    {
        return new ChargePhaseEvent(this);
    }
}