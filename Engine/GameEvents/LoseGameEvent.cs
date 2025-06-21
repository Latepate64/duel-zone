using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Engine.GameEvents;

public class LoseGameEvent(IPlayerV2 player) : GameEventV2(player, false)
{
    internal override IEnumerable<GameEventV2> Happen(GameState state)
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