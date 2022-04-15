using Engine.Zones;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    class GameState : IGameState
    {
        public IBattleZone BattleZone { get; } = new BattleZone();
        public IList<IPlayer> Players { get; }

        public GameState(IGameState state)
        {
            BattleZone = state.BattleZone.Copy();
            Players = state.Players.Select(x => x.Copy()).ToList();
        }
        public GameState(params IPlayer[] players)
        {
            Players = players.ToList();
        }

        public IGameState Copy()
        {
            return new GameState(this);
        }
    }
}
