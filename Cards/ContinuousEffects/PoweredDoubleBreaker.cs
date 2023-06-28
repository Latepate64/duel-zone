using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class PoweredDoubleBreaker : ContinuousEffect, IBreakerEffect
    {
        public PoweredDoubleBreaker() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PoweredDoubleBreaker();
        }

        public int GetAmount(ICard creature)
        {
            return IsSourceOfAbility(creature) && Source.Power >= 6000 ? 2 : 1;
        }

        public override string ToString()
        {
            return "While this creature has power 6000 or more, it has \"double breaker.\"";
        }
    }
}