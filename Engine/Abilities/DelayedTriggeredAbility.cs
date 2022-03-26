using Engine.Durations;
using System;

namespace Engine.Abilities
{
    public class DelayedTriggeredAbility : IDisposable, IDurationable
    {
        internal ITriggeredAbility TriggeredAbility { get; private set; }
        public IDuration Duration { get; private set; }

        /// <summary>
        /// 603.7b
        /// A delayed triggered ability will trigger only once—
        /// the next time its trigger event occurs—
        /// unless it has a stated duration, such as “this turn.” 
        /// </summary>
        internal bool TriggersOnlyOnce { get; private set; }

        public DelayedTriggeredAbility(ITriggeredAbility triggeredAbility, Guid source, Guid owner, IDuration duration)
        {
            TriggeredAbility = triggeredAbility;
            TriggeredAbility.Source = source;
            TriggeredAbility.Owner = owner;
            Duration = duration;
            TriggersOnlyOnce = false;
        }

        public DelayedTriggeredAbility(ITriggeredAbility triggeredAbility, Guid source, Guid owner) : this(triggeredAbility, source, owner, new Indefinite())
        {
            TriggersOnlyOnce = true;
        }

        internal DelayedTriggeredAbility(DelayedTriggeredAbility ability)
        {
            TriggeredAbility = ability.TriggeredAbility.Copy() as ITriggeredAbility;
            Duration = ability.Duration.Copy();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //TODO: Make abilities disposable
                //TriggeredAbility.Dispose();
                TriggeredAbility = null;
                Duration.Dispose();
                Duration = null;
            }
        }
    }
}
