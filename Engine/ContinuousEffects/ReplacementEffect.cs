using Common.GameEvents;
using System;

namespace Engine.ContinuousEffects
{
    /// <summary>
    /// 614.1. Some continuous effects are replacement effects.
    /// Like prevention effects (see rule 615), replacement effects apply continuously as events happen—they aren’t locked in ahead of time.
    /// Such effects watch for a particular event that would happen and completely or partially replace that event with a different event.
    /// They act like “shields” around whatever they’re affecting.
    /// </summary>
    public abstract class ReplacementEffect : ContinuousEffect
    {
        protected ReplacementEffect(IGameEvent eventToReplace, ICardFilter filter) : base(filter)
        {
            Id = Guid.NewGuid();
            EventToReplace = eventToReplace;
        }

        protected ReplacementEffect(ReplacementEffect effect) : base(effect)
        {
            Id = effect.Id;
            EventToReplace = effect.EventToReplace.Copy();
        }

        public IGameEvent EventToReplace { get; set; }

        public Guid Id { get; }

        public abstract bool Replaceable(IGameEvent gameEvent, IGame game);

        public abstract bool Apply(Game game, IPlayer player);
    }
}
