using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsPowerEffect : ContinuousEffect, IPowerModifyingEffect, IPowerable
    {
        public ThisCreatureGetsPowerEffect(ThisCreatureGetsPowerEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public ThisCreatureGetsPowerEffect(int power) : base()
        {
            Power = power;
        }

        public int Power { get; }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            Source.Power += Power;
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power.";
        }
    }
}