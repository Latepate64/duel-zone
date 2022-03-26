﻿namespace Engine.ContinuousEffects
{
    /// <summary>
    /// TODO: Apply in engine
    /// </summary>
    public abstract class CostModifyingEffect : ContinuousEffect
    {
        public int CostChange { get; set; }

        protected CostModifyingEffect(int costChange, ICardFilter filter, IDuration duration) : base(filter, duration)
        {
            CostChange = costChange;
        }

        protected CostModifyingEffect(CostModifyingEffect effect) : base(effect)
        {
            CostChange = effect.CostChange;
        }
    }
}
