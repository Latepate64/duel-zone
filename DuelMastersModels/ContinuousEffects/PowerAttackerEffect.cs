using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class PowerAttackerEffect : ContinuousEffect
    {
        public int Power { get; }

        public PowerAttackerEffect(CardFilter filter, Duration duration, int power) : base(filter, duration)
        {
            Power = power;
        }

        public PowerAttackerEffect(PowerAttackerEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public override ContinuousEffect Copy()
        {
            return new PowerAttackerEffect(this);
        }
    }
}
