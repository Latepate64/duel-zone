using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsPowerForEachShieldYouHaveEffect : PowerModifyingMultiplierEffect
    {
        public ThisCreatureGetsPowerForEachShieldYouHaveEffect(int power) : base(power)
        {
        }

        public ThisCreatureGetsPowerForEachShieldYouHaveEffect(ThisCreatureGetsPowerForEachShieldYouHaveEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerForEachShieldYouHaveEffect(this);
        }

        public override string ToString()
        {
            return $"This creature gets +{_power} power for each shield you have.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return Controller.ShieldZone.Cards.Count;
        }
    }
}