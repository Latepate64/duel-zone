using Engine;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class ThisCreatureCannotAttackAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCannotAttackAbility(params Condition[] conditions) : base(new ThisCreatureCannotAttackEffect(conditions)) { }
    }

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
