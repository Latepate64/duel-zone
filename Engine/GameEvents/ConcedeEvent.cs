using System.Linq;

namespace Engine.GameEvents;

public class ConcedeEvent(PlayerV2 player) : PlayerAction(player)
{
    internal override bool Happen(GameState state, PlayerAction action)
    {
        state.Losers.Add(Player);
        var remainingPlayers = state.Players.Where(x => x != Player);
        if (remainingPlayers.Count() == 1)
        {
            state.Winner = remainingPlayers.Single();
        }
        return true;
    }
}