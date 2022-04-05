﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.ContinuousEffects
{
    /// <summary>
    /// 611.1. A continuous effect modifies characteristics of objects, modifies control of objects, or affects players or the rules of the game, for a fixed or indefinite period.
    /// </summary>
    public abstract class ContinuousEffect : ITimestampable, IContinuousEffect
    {
        /// <summary>
        /// 611.2a A continuous effect generated by the resolution of a spell or ability lasts as long as stated by the spell or ability creating it (such as “until end of turn”). If no duration is stated, it lasts until the end of the game.
        /// </summary>
        public IDuration Duration { get; private set; }

        /// <summary>
        /// Filter that can be applied to find cards affected by the effect.
        /// </summary>
        public ICardFilter Filter { get; set; }

        public Guid SourceAbility { get; set; }

        public int Timestamp { get; set; }

        protected ContinuousEffect(ICardFilter filter, IDuration duration)
        {
            Duration = duration;
            Filter = filter;
        }

        protected ContinuousEffect(ContinuousEffect effect)
        {
            Duration = effect.Duration;
            Filter = effect.Filter?.Copy();
            SourceAbility = effect.SourceAbility;
        }

        public abstract IContinuousEffect Copy();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Duration.Dispose();
                Duration = null;
                Filter.Dispose();
                Filter = null;
                SourceAbility = Guid.Empty;
            }
        }

        public override abstract string ToString();

        protected IEnumerable<ICard> GetAffectedCards(IGame game)
        {
            return game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetOwner(card)));
        }
    }
}
