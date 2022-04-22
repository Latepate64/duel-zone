using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class TripleBreakerEffect : ContinuousEffect, IBreakerEffect
    {
        public TripleBreakerEffect() : base()
        {
        }

        public TripleBreakerEffect(TripleBreakerEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TripleBreakerEffect(this);
        }

        public int GetAmount(IGame game, ICard creature)
        {
            return IsSourceOfAbility(creature) ? 3 : 1;
        }

        public override string ToString()
        {
            return "Triple breaker";
        }
    }
}
