using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    /// <summary>
    /// 611.1. A continuous effect modifies characteristics of objects, modifies control of objects, or affects players or the rules of the game, for a fixed or indefinite period.
    /// </summary>
    public abstract class ContinuousEffect : Effect, IContinuousEffect, ITimestampable
    {
        public int Timestamp { get; set; }

        protected ContinuousEffect()
        {
        }

        protected ContinuousEffect(IContinuousEffect effect) : base(effect)
        {
        }

        public abstract IContinuousEffect Copy();
    }
}
