using DuelMastersModels.Durations;
using System;

namespace DuelMastersModels.Abilities
{
    public class DelayedTriggeredAbility : IDisposable
    {
        internal TriggeredAbility TriggeredAbility { get; private set; }
        internal Duration Duration { get; private set; }

        public DelayedTriggeredAbility(TriggeredAbility triggeredAbility, Duration duration, Guid source, Guid controller)
        {
            TriggeredAbility = triggeredAbility;
            TriggeredAbility.Source = source;
            TriggeredAbility.Controller = controller;
            TriggeredAbility.Resolvable.Source = source;
            TriggeredAbility.Resolvable.Controller = controller;
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
