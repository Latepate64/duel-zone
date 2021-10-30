using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class UnblockableEffect : ContinuousEffect
    {
        public UnblockableEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {

        }

        public UnblockableEffect(UnblockableEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new UnblockableEffect(this);
        }
    }
}
