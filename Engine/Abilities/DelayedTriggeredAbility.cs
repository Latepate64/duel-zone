﻿using System;

namespace Engine.Abilities
{
    public abstract class DelayedTriggeredAbility : IDisposable, ICopyable<DelayedTriggeredAbility>
    {
        internal ITriggeredAbility TriggeredAbility { get; private set; }

        /// <summary>
        /// 603.7b
        /// A delayed triggered ability will trigger only once—
        /// the next time its trigger event occurs—
        /// unless it has a stated duration, such as “this turn.” 
        /// </summary>
        internal bool TriggersOnlyOnce { get; private set; }

        public DelayedTriggeredAbility(ITriggeredAbility triggeredAbility, ICard source, IPlayer owner, bool triggersOnlyOnce)
        {
            TriggeredAbility = triggeredAbility;
            TriggeredAbility.Source = source;
            TriggeredAbility.Controller = owner;
            TriggersOnlyOnce = triggersOnlyOnce;
        }

        public DelayedTriggeredAbility(DelayedTriggeredAbility ability)
        {
            TriggeredAbility = ability.TriggeredAbility.Copy() as ITriggeredAbility;
            TriggersOnlyOnce = ability.TriggersOnlyOnce;
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
            }
        }

        public abstract DelayedTriggeredAbility Copy();
    }
}
