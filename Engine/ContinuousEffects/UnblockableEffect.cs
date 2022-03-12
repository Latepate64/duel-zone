using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public class UnblockableEffect : ContinuousEffect
    {
        public CardFilter BlockerFilter { get; }

        public UnblockableEffect(CardFilter filter, Duration duration, CardFilter blockerFilter, params Condition[] conditions) : base(filter, duration, conditions)
        {
            BlockerFilter = blockerFilter;
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
