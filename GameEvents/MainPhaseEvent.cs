using Interfaces;

namespace GameEvents;

public sealed class MainPhaseEvent(IPlayerV2 player) : GameEventV2(player, false)
{
    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        if (Player.Hand.HasCards)
        {
            // TODO: Check if any card can actually be used?
            return [new UseCardEvent(Player)];
        }
        return [];
    }
}