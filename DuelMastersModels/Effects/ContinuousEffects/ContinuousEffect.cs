using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    /// <summary>
    /// A continuous effect modifies characteristics of objects, modifies control of objects, or affects players or the rules of the game, for a fixed or indefinite period.
    /// </summary>
    public abstract class ContinuousEffect : Effect
    {
        public Period Period { get; private set; }

        protected ContinuousEffect(Period period)
        {
            Period = period;
        }
    }
}
