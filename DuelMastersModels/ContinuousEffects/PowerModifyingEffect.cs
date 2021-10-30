using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class PowerModifyingEffect : ContinuousEffect
    {
        public int Power { get; set; }

        public PowerModifyingEffect(CardFilter filter, int power, Duration duration) : base(filter, duration)
        {
            Power = power;
        }

        public PowerModifyingEffect(PowerModifyingEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public override ContinuousEffect Copy()
        {
            return new PowerModifyingEffect(this);
        }
    }
}
