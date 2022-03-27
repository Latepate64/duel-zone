using Engine;

namespace Cards.StaticAbilities
{
    class ThisCreatureCannotAttackAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCannotAttackAbility(params Condition[] conditions) : base(new ContinuousEffects.ThisCreatureCannotAttackEffect(conditions)) { }
    }
}