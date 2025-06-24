using Interfaces;

namespace GameEvents;

public sealed class PassAction(IPlayerV2 player) : GameEventV2(player, false), IPassAction
{
    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        return [];
    }
}
