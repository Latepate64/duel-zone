using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class PowerAttackerEffect : ContinuousEffect
    {
        public PowerAttackerEffect(ContinuousEffect effect) : base(effect)
        {
        }

        public PowerAttackerEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new PowerAttackerEffect(this);
        }
    }
}
