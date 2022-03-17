using System;

namespace Engine.ContinuousEffects
{
    /// <summary>
    /// TODO: Apply in engine
    /// </summary>
    public class CostModifyingEffect : ContinuousEffect
    {
        public int CostChange { get; set; }

        public CostModifyingEffect(int costChange, CardFilter filter) : base(filter)
        {
            CostChange = costChange;
        }

        public CostModifyingEffect(CostModifyingEffect effect) : base(effect)
        {
            CostChange = effect.CostChange;
        }

        public override ContinuousEffect Copy()
        {
            return new CostModifyingEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} cost {Math.Abs(CostChange)} {(CostChange > 0 ? "more" : "less")}";
        }
    }
}
