using Interfaces;

namespace GameEvents;

public class LoseGameEvent : GameEventV2
{
    public LoseGameEvent(IPlayerV2 player) : base(player, false)
    {
    }

    LoseGameEvent(IGameEventV2 gameEvent) : base(gameEvent)
    {
    }

    public override IGameEventV2 Copy()
    {
        return new LoseGameEvent(this);
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        state.Losers.Add(Player);
        var remainingPlayers = state.Players.Where(x => x != Player);
        if (remainingPlayers.Count() == 1)
        {
            state.Winner = remainingPlayers.Single();
        }
        return [];
    }
}