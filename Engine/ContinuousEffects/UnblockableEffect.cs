namespace Engine.ContinuousEffects
{
    public abstract class UnblockableEffect : ContinuousEffect
    {
        public ICardFilter BlockerFilter { get; }

        protected UnblockableEffect(ICardFilter filter, IDuration duration, ICardFilter blockerFilter, params Condition[] conditions) : base(filter, duration, conditions)
        {
            BlockerFilter = blockerFilter;
        }

        protected UnblockableEffect(UnblockableEffect effect) : base(effect)
        {
            BlockerFilter = effect.BlockerFilter;
        }
    }
}
