using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class DoubleBreakerEffect : BreakerEffect
    {
        public DoubleBreakerEffect()
        {
        }

        public DoubleBreakerEffect(DoubleBreakerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new DoubleBreakerEffect(this);
        }

        public override int GetAmount()
        {
            return 2;
        }

        public override string ToString()
        {
            return "Double breaker";
        }
    }
}
