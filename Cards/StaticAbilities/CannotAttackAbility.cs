using Engine.ContinuousEffects;
namespace Cards.StaticAbilities
{
    class CannotAttackAbility : Engine.Abilities.StaticAbility
    {
        public CannotAttackAbility(params Engine.Condition[] conditions) : base(new CannotAttackCreaturesEffect(new Engine.TargetFilter(), conditions), new CannotAttackPlayersEffect(new Engine.TargetFilter(), conditions)) { }
    }
}
