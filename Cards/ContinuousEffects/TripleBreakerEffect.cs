using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class TripleBreakerEffect : BreakerEffect
    {
        public TripleBreakerEffect() : base(new Durations.Indefinite())
        {
        }

        public TripleBreakerEffect(TripleBreakerEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TripleBreakerEffect(this);
        }

        public override int GetAmount(Engine.IGame game)
        {
            return 3;
        }

        public override string ToString()
        {
            return "Triple breaker";
        }
    }
}
