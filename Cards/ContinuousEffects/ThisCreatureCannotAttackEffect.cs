using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotAttackEffect : CannotAttackEffect
    {
        public ThisCreatureCannotAttackEffect(params Condition[] conditions) : base(new TargetFilter(), new Durations.Indefinite(), conditions)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotAttackEffect();
        }

        public override string ToString()
        {
            return "This creature can't attack.";
        }
    }
}