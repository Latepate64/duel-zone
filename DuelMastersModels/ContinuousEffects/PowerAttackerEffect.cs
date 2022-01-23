using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class PowerAttackerEffect : ContinuousEffect
    {
        public int Power { get; }

        public PowerAttackerEffect(PowerAttackerEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public PowerAttackerEffect(CardFilter filter, Duration duration, int power) : base(filter, duration)
        {
            Power = power;
        }

        public override ContinuousEffect Copy()
        {
            return new PowerAttackerEffect(this);
        }

        public virtual int GetPower(Game game)
        {
            return Power;
        }
    }
}
