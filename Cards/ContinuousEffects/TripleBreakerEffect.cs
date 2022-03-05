using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class TripleBreakerEffect : BreakerEffect
    {
        public TripleBreakerEffect()
        {
        }

        public TripleBreakerEffect(TripleBreakerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new TripleBreakerEffect(this);
        }

        public override int GetAmount()
        {
            return 3;
        }

        public override string ToString()
        {
            return "Triple breaker";
        }
    }
}
