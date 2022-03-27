using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class DoubleBreakerEffect : BreakerEffect
    {
        public DoubleBreakerEffect(params Engine.Condition[] conditions) : base(new Durations.Indefinite(), conditions)
        {
        }

        public DoubleBreakerEffect(DoubleBreakerEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new DoubleBreakerEffect(this);
        }

        public override int GetAmount(Engine.IGame game)
        {
            return 2;
        }

        public override string ToString()
        {
            return "Double breaker";
        }
    }
}
