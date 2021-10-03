using DuelMastersModels.Effects.Durations;
using System;

namespace DuelMastersModels.Abilities
{
    public class DelayedTriggeredAbility : IDisposable
    {
        internal TriggeredAbility TriggeredAbility { get; private set; }
        internal Duration Period { get; private set; }

        public DelayedTriggeredAbility(TriggeredAbility triggeredAbility, Duration period, Guid source, Guid controller)
        {
            TriggeredAbility = triggeredAbility;
            TriggeredAbility.Source = source;
            TriggeredAbility.Controller = controller;
            Period = period;
        }

        internal DelayedTriggeredAbility(DelayedTriggeredAbility ability)
        {
            TriggeredAbility = ability.TriggeredAbility.Copy() as TriggeredAbility;
            Period = ability.Period.Copy();
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
                Period.Dispose();
                Period = null;
            }
        }
    }
}
