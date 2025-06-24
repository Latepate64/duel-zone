using Interfaces;

namespace GameEvents;

public sealed class ChargePhaseEvent(IPlayerV2 player) : GameEventV2(player, false)
{
    bool shouldEnd;

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
}