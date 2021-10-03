﻿using DuelMastersModels.Effects.Periods;
using System;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    /// <summary>
    /// A continuous effect modifies characteristics of objects, modifies control of objects, or affects players or the rules of the game, for a fixed or indefinite period. A continuous effect may be generated by the resolution of a spell or ability.
    /// </summary>
    public abstract class ContinuousEffect : Effect, IDisposable
    {
        /// <summary>
        /// A continuous effect generated by the resolution of a spell or ability lasts as long as stated by the spell or ability creating it (such as “until end of turn”). If no duration is stated, it lasts until the end of the game.
        /// </summary>
        public Period Period { get; private set; }

        protected ContinuousEffect(Period period)
        {
            Period = period;
        }

        protected ContinuousEffect(ContinuousEffect effect)
        {
            Period = effect.Period.Copy();
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
                Period.Dispose();
                Period = null;
            }
        }
    }

    public class PowerModifyingEffect : ContinuousEffect
    {
        public int Power { get; }
        public Guid Target { get; }

        public PowerModifyingEffect(Period period, int power, Guid target) : base(period)
        {
            Power = power;
            Target = target;
        }

        public PowerModifyingEffect(PowerModifyingEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new PowerModifyingEffect(this);
        }
    }
}
