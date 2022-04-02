using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class PoweredTripleBreaker : BreakerEffect
    {
        public PoweredTripleBreaker() : base(new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PoweredTripleBreaker();
        }

        public override int GetAmount(IGame game)
        {
            var power = game.GetCard(game.GetAbility(SourceAbility).Source).Power;
            return power >= 15000 ?
                3 :
                power >= 6000 ?
                    2 :
                    1;
        }

        public override string ToString()
        {
            return "While this creature has power 6000 or more, it has \"double breaker.\" While this creature has power 15000 or more, it has \"triple breaker\" instead of \"double breaker.\"";
        }
    }
}