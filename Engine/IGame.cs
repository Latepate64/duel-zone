using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Engine
{
    public interface IGame
    {
        List<IPlayer> Players { get; }

        IEnumerable<T> GetContinuousEffects<T>(Card card) where T : IContinuousEffect;
        void Play(IPlayer startingPlayer, IPlayer otherPlayer);
    }
}