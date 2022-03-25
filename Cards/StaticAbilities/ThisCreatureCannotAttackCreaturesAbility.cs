using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class ThisCreatureCannotAttackCreaturesAbility : StaticAbility
    {
        public ThisCreatureCannotAttackCreaturesAbility(params Condition[] conditions) : base(new ThisCreatureCannotAttackCreaturesEffect(conditions))
        {
        }
    }

    public class ThisCreatureCannotAttackCreaturesEffect : CannotAttackCreaturesEffect
    {
        public ThisCreatureCannotAttackCreaturesEffect(params Condition[] conditions) : base(new TargetFilter(), conditions)
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
