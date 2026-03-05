using Interfaces;

namespace GameEvents;

public sealed class MainPhaseEvent : GameEventV2
{
    public MainPhaseEvent(IPlayerV2 player) : base(player, false)
    {
    }

    MainPhaseEvent(IGameEventV2 gameEvent) : base(gameEvent)
    {
    }

    public override IGameEventV2 Copy()
    {
        return new MainPhaseEvent(this);
    }

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