using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeAttackedEffect : ContinuousEffect, ICannotBeAttackedEffect
    {
        public ThisCreatureCannotBeAttackedEffect() : base(new TargetFilter(), new Durations.Indefinite())
        {
        }

        public bool Applies(ICard attacker)
        {
            return true;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeAttackedEffect();
        }

        public override string ToString()
        {
            return "This creature can't be attacked.";
        }
    }
}