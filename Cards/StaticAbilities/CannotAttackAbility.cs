using Engine.ContinuousEffects;
namespace Cards.StaticAbilities
{
    class CannotAttackAbility : Engine.Abilities.StaticAbility
    {
        public CannotAttackAbility(params Engine.Condition[] conditions) : base(new CannotAttackEffect(new Engine.TargetFilter(), conditions)) { }
    }
}
