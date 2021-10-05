﻿using DuelMastersModels.Durations;
using System;

namespace DuelMastersModels.ContinuousEffects
{
    /// <summary>
    /// A continuous effect modifies characteristics of objects, modifies control of objects, or affects players or the rules of the game, for a fixed or indefinite period. A continuous effect may be generated by the resolution of a spell or ability.
    /// </summary>
    public abstract class ContinuousEffect : Effect, IDisposable
    {
        /// <summary>
        /// A continuous effect generated by the resolution of a spell or ability lasts as long as stated by the spell or ability creating it (such as “until end of turn”). If no duration is stated, it lasts until the end of the game.
        /// </summary>
        public Duration Duration { get; set; }

        public CardFilter Filter { get; set; }

        protected ContinuousEffect(CardFilter filter)
        {
            Duration = new Indefinite();
            Filter = filter;
        }

        protected ContinuousEffect(ContinuousEffect effect)
        {
            Duration = effect.Duration.Copy();
            Filter = effect.Filter.Copy();
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
                Duration.Dispose();
                Duration = null;
                Filter.Dispose();
                Filter = null;
            }
        }
    }

    public class PowerModifyingEffect : ContinuousEffect
    {
        public int Power { get; set; }

        public PowerModifyingEffect(CardFilter filter, int power) : base(filter)
        {
            Power = power;
        }

        public PowerModifyingEffect(PowerModifyingEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public override ContinuousEffect Copy()
        {
            return new PowerModifyingEffect(this);
        }
    }

    public class SpeedAttackerEffect : ContinuousEffect
    {
        public SpeedAttackerEffect(CardFilter filter) : base(filter)
        {
        }

        public SpeedAttackerEffect(SpeedAttackerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new SpeedAttackerEffect(this);
        }
    }

    public class DoubleBreakerEffect : ContinuousEffect
    {
        public DoubleBreakerEffect(CardFilter filter) : base(filter)
        {

        }

        public DoubleBreakerEffect(DoubleBreakerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new DoubleBreakerEffect(this);
        }
    }

    public class AttacksIfAbleEffect : ContinuousEffect
    {
        public AttacksIfAbleEffect(CardFilter filter) : base(filter)
        {

        }

        public AttacksIfAbleEffect(AttacksIfAbleEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new AttacksIfAbleEffect(this);
        }
    }
}
