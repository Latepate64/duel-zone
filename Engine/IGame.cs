using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Engine
{
    public interface IGame
    {
        List<Player> Players { get; }

        IEnumerable<T> GetContinuousEffects<T>(Card card) where T : IContinuousEffect;
        void Play(Player startingPlayer, Player otherPlayer);
    }
}