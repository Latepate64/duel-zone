using Engine.Zones;
using System.Collections.Generic;

namespace Engine
{
    public interface IGameState : ICopyable<IGameState>
    {
        IBattleZone BattleZone { get; }
        IList<IPlayer> Players { get; }
        SpellStack SpellStack { get; }
    }
}
