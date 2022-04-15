using Engine.Abilities;
using Engine.Zones;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    class GameState : IGameState
    {
        public IBattleZone BattleZone { get; } = new BattleZone();
        public List<DelayedTriggeredAbility> DelayedTriggeredAbilities { get; } = new List<DelayedTriggeredAbility>();
        public IList<IPlayer> Players { get; }
        public SpellStack SpellStack { get; } = new SpellStack();

        public GameState(IGameState state)
        {
            BattleZone = state.BattleZone.Copy();
            DelayedTriggeredAbilities = state.DelayedTriggeredAbilities.Select(x => x.Copy()).ToList();
            Players = state.Players.Select(x => x.Copy()).ToList();
            SpellStack = state.SpellStack.Copy();
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
