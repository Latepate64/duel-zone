using Engine.GameEvents;
using System;

namespace Engine.ContinuousEffects
{
    /// <summary>
    /// 614.1. Some continuous effects are replacement effects. Like prevention effects (see rule 615),
    /// replacement effects apply continuously as events happen—they aren’t locked in ahead of time. Such
    /// effects watch for a particular event that would happen and completely or partially replace that event
    /// with a different event. They act like “shields” around whatever they’re affecting.
    /// </summary>
    public interface IReplacementEffect : IContinuousEffect
    {
        Guid Id { get; }

        bool CanBeApplied(IGameEvent gameEvent, IGame game);
        IGameEvent Apply(IGameEvent gameEvent, IGame game);
    }
}