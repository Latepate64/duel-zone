using Engine.Durations;
using System;

namespace Engine.Abilities
{
    public class DelayedTriggeredAbility : IDisposable
    {
        internal TriggeredAbility TriggeredAbility { get; private set; }
        internal Duration Duration { get; private set; }

        public DelayedTriggeredAbility(TriggeredAbility triggeredAbility, Duration duration, Guid source, Guid owner)
        {
            TriggeredAbility = triggeredAbility;
            TriggeredAbility.Source = source;
            TriggeredAbility.Owner = owner;
            Duration = duration;
        }

        internal DelayedTriggeredAbility(DelayedTriggeredAbility ability)
        {
            TriggeredAbility = ability.TriggeredAbility.Copy() as TriggeredAbility;
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
