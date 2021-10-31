using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class UnblockableEffect : ContinuousEffect
    {
        public CardFilter BlockerFilter { get; }

        public UnblockableEffect(CardFilter filter, Duration duration, CardFilter blockerFilter) : base(filter, duration)
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
    }
}
