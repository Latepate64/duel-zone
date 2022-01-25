using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class CanBeAttackedAsThoughTappedEffect : ContinuousEffect
    {
        public CanBeAttackedAsThoughTappedEffect(ContinuousEffect effect) : base(effect)
        {
        }

        public CanBeAttackedAsThoughTappedEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new CanBeAttackedAsThoughTappedEffect(this);
        }
    }
}
