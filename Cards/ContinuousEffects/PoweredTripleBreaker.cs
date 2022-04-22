using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class PoweredTripleBreaker : ContinuousEffect, IBreakerEffect
    {
        public PoweredTripleBreaker() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PoweredTripleBreaker();
        }

        public int GetAmount(IGame game, ICard creature)
        {
            if (IsSourceOfAbility(creature))
            {
                var power = Source.Power;
                return power >= 15000 ?
                    3 :
                    power >= 6000 ?
                        2 :
                        1;
            }
            else
            {
                return 1;
            }
        }

        public override string ToString()
        {
            return "While this creature has power 6000 or more, it has \"double breaker.\" While this creature has power 15000 or more, it has \"triple breaker\" instead of \"double breaker.\"";
        }
    }
}