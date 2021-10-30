using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class DoubleBreakerEffect : ContinuousEffect
    {
        public DoubleBreakerEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {

        }

        public DoubleBreakerEffect(DoubleBreakerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new DoubleBreakerEffect(this);
        }
    }
}
