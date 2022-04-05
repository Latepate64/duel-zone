using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class DoubleBreakerEffect : ContinuousEffect, IBreakerEffect
    {
        public DoubleBreakerEffect() : base(new Engine.TargetFilter())
        {
        }

        public DoubleBreakerEffect(DoubleBreakerEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new DoubleBreakerEffect(this);
        }

        public int GetAmount(Engine.IGame game)
        {
            return 2;
        }

        public override string ToString()
        {
            return "Double breaker";
        }
    }
}
