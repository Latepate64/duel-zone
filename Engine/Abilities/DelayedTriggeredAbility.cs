using Engine.Durations;
using System;

namespace Engine.Abilities
{
    internal class DelayedTriggeredAbility : IDisposable
    {
        internal ITriggeredAbility TriggeredAbility { get; private set; }
        internal IDuration Duration { get; private set; }

        public DelayedTriggeredAbility(ITriggeredAbility triggeredAbility, IDuration duration, Guid source, Guid owner)
        {
            TriggeredAbility = triggeredAbility;
            TriggeredAbility.Source = source;
            TriggeredAbility.Owner = owner;
            Duration = duration;
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
