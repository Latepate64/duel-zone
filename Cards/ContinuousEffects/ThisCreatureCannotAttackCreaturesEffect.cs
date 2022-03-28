using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureCannotAttackCreaturesEffect : CannotAttackCreaturesEffect
    {
        public ThisCreatureCannotAttackCreaturesEffect(params Condition[] conditions) : base(new TargetFilter(), new Durations.Indefinite(), conditions)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new ThisCreatureCannotAttackCreaturesEffect();
        }

        public override string ToString()
        {
            return "This creature can't attack creatures.";
        }
    }
}