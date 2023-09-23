using Engine;
using System.Collections.Generic;

namespace Simulator
{
    public interface ISimulator
    {
        Game PlayDuel(Player player1, Player player2);
        void PlayRoundOfGames(SimulationConfiguration conf, List<MatchUp> matchUps);
    }
}