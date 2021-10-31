﻿using DuelMastersModels.Durations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.ContinuousEffects
{
    /// <summary>
    /// A continuous effect modifies characteristics of objects, modifies control of objects, or affects players or the rules of the game, for a fixed or indefinite period. A continuous effect may be generated by the resolution of a spell or ability.
    /// </summary>
    public abstract class ContinuousEffect : IDisposable
    {
        /// <summary>
        /// A continuous effect generated by the resolution of a spell or ability lasts as long as stated by the spell or ability creating it (such as “until end of turn”). If no duration is stated, it lasts until the end of the game.
        /// </summary>
        public Duration Duration { get; set; }

        public ICollection<CardFilter> Filters { get; }

        public Guid Controller { get; set; }

        protected ContinuousEffect(CardFilter filter, Duration duration) : this(new List<CardFilter> { filter }, duration)
        {
        }

        protected ContinuousEffect(IEnumerable<CardFilter> filters, Duration duration)
        {
            Filters = filters.ToList();
            Duration = duration;
        }

        protected ContinuousEffect(ContinuousEffect effect)
        {
            Controller = effect.Controller;
            Duration = effect.Duration.Copy();
            Filters = effect.Filters.Select(x => x.Copy()).ToList();
        }

        public abstract ContinuousEffect Copy();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Controller = Guid.Empty;
                Duration.Dispose();
                Duration = null;
                foreach (var filter in Filters)
                {
                    filter.Dispose();
                }
                Filters.Clear();
            }
        }
    }
}
