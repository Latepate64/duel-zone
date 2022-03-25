using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public abstract class UnblockableEffect : ContinuousEffect
    {
        public ICardFilter BlockerFilter { get; }

        protected UnblockableEffect(ICardFilter filter, IDuration duration, ICardFilter blockerFilter, params Condition[] conditions) : base(filter, duration, conditions)
        {
            BlockerFilter = blockerFilter;
        }

        protected UnblockableEffect(ICardFilter filter, ICardFilter blockerFilter, params Condition[] conditions) : this(filter, new Indefinite(), blockerFilter, conditions)
        {
        }

        protected UnblockableEffect(UnblockableEffect effect) : base(effect)
        {
            BlockerFilter = effect.BlockerFilter;
        }
    }
}
