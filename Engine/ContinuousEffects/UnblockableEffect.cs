using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public class UnblockableEffect : ContinuousEffect
    {
        public CardFilter BlockerFilter { get; }

        public UnblockableEffect(CardFilter filter, IDuration duration, CardFilter blockerFilter, params Condition[] conditions) : base(filter, duration, conditions)
        {
            BlockerFilter = blockerFilter;
        }

        public UnblockableEffect(CardFilter filter, CardFilter blockerFilter, params Condition[] conditions) : this(filter, new Indefinite(), blockerFilter, conditions)
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
