using Interfaces;

namespace GameEvents;

public class LoseGameEvent(IPlayerV2 player) : GameEventV2(player, false)
{
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