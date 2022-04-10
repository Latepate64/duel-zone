using Engine.GameEvents;
using System;

namespace Engine.ContinuousEffects
{
    public interface IReplacementEffect : IContinuousEffect
    {
        IGameEvent EventToReplace { get; set; }
        Guid Id { get; }

        bool Apply(IGame game, IPlayer player, ICard creature);
        bool Replaceable(IGameEvent gameEvent, IGame game);
    }
}