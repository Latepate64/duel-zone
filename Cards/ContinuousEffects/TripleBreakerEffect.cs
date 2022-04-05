using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class TripleBreakerEffect : ContinuousEffect, IBreakerEffect
    {
        public TripleBreakerEffect() : base(new Engine.TargetFilter())
        {
        }

        public TripleBreakerEffect(TripleBreakerEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TripleBreakerEffect(this);
        }

        public int GetAmount(Engine.IGame game)
        {
            return 3;
        }

        public override string ToString()
        {
            return "Triple breaker";
        }
    }
}
