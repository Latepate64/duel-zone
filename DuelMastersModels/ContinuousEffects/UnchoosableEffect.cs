using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class UnchoosableEffect : ContinuousEffect
    {
        public UnchoosableEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {
        }

        public UnchoosableEffect(UnchoosableEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new UnchoosableEffect(this);
        }
    }
}
