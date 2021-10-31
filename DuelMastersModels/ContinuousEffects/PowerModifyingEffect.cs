using DuelMastersModels.Durations;
using System.Collections.Generic;

namespace DuelMastersModels.ContinuousEffects
{
    public class PowerModifyingEffect : ContinuousEffect
    {
        private readonly int _power;

        public PowerModifyingEffect(CardFilter filter, int power, Duration duration) : base(filter, duration)
        {
            _power = power;
        }

        public PowerModifyingEffect(IEnumerable<CardFilter> filters, int power, Duration duration) : base(filters, duration)
        {
            _power = power;
        }

        public PowerModifyingEffect(PowerModifyingEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public override ContinuousEffect Copy()
        {
            return new PowerModifyingEffect(this);
        }

        public virtual int GetPower(Duel duel)
        {
            return _power;
        }
    }
}
