using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class PoweredDoubleBreaker : BreakerEffect
    {
        public PoweredDoubleBreaker() : base(new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PoweredDoubleBreaker();
        }

        public override int GetAmount(IGame game)
        {
            return game.GetCard(game.GetAbility(SourceAbility).Source).Power >= 6000 ? 2 : 1;
        }

        public override string ToString()
        {
            return "While this creature has power 6000 or more, it has \"double breaker.\"";
        }
    }
}