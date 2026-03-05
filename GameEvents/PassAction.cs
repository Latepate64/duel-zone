using Interfaces;

namespace GameEvents;

public sealed class PassAction : GameEventV2, IPassAction
{
    public PassAction(IPlayerV2 player) : base(player, false)
    {
    }

    PassAction(IGameEventV2 gameEvent) : base(gameEvent)
    {
    }

    public override IGameEventV2 Copy()
    {
        return new PassAction(this);
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        return [];
    }
}
