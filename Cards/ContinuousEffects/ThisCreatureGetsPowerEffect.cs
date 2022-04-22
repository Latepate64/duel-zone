using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsPowerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        private readonly int _power;

        public ThisCreatureGetsPowerEffect(ThisCreatureGetsPowerEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public ThisCreatureGetsPowerEffect(int power) : base()
        {
            _power = power;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            Source.Power += _power;
        }

        public override string ToString()
        {
            return $"This creature gets +{_power} power.";
        }
    }
}