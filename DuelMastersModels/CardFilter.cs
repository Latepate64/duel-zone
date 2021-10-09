﻿using System;

namespace DuelMastersModels
{
    public abstract class CardFilter : IDisposable
    {
        /// <summary>
        /// Target and/or source of the filter. Not all filters need to consider this in applying the filter. (eg. for creature with Speed Attacker ability this is the creature, for Super Sonic Jetpack selection this is the target of the effect)
        /// </summary>
        public Guid Target { get; set; }

        public Guid Owner { get; set; }

        protected CardFilter() { }

        protected CardFilter(CardFilter filter)
        {
            Target = filter.Target;
            Owner = filter.Owner;
        }

        public abstract bool Applies(Card card, Duel duel);

        public abstract CardFilter Copy();

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}