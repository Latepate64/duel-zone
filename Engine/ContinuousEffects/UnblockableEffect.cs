using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public class UnblockableEffect : ContinuousEffect
    {
        public ICardFilter BlockerFilter { get; }

        public UnblockableEffect(ICardFilter filter, IDuration duration, ICardFilter blockerFilter, params Condition[] conditions) : base(filter, duration, conditions)
        {
            BlockerFilter = blockerFilter;
        }

        public UnblockableEffect(ICardFilter filter, ICardFilter blockerFilter, params Condition[] conditions) : this(filter, new Indefinite(), blockerFilter, conditions)
        {
        }

        public UnblockableEffect(UnblockableEffect effect) : base(effect)
        {
            BlockerFilter = effect.BlockerFilter;
        }

        public override ContinuousEffect Copy()
        {
            return new UnblockableEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} can't be blocked{GetDurationAsText()}.";
        }
    }
}
