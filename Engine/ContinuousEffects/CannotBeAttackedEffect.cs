﻿namespace Engine.ContinuousEffects
{
    public abstract class CannotBeAttackedEffect : ContinuousEffect
    {
        public ICardFilter AttackerFilter { get; }

        protected CannotBeAttackedEffect(CannotBeAttackedEffect effect) : base(effect)
        {
            AttackerFilter = effect.AttackerFilter.Copy();
        }

        protected CannotBeAttackedEffect(ICardFilter filter, ICardFilter attackerFilter, IDuration duration) : base(filter, duration)
        {
            AttackerFilter = attackerFilter;
        }
    }
}
