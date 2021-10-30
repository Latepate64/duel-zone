using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class ChargerEffect : ContinuousEffect
    {
        public ChargerEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {

        }

        public ChargerEffect(ChargerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new ChargerEffect(this);
        }
    }
}
