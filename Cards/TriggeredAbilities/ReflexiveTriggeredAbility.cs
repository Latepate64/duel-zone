using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    /// <summary>
    /// 603.12.
    /// </summary>
    class ReflexiveTriggeredAbility : ResolvableAbility
    {
        public ReflexiveTriggeredAbility(IOneShotEffect effect, IAbility ability) : base(effect)
        {
            Controller = ability.Controller;
            Source = ability.Source;
        }

        public ReflexiveTriggeredAbility(ReflexiveTriggeredAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new ReflexiveTriggeredAbility(this);
        }

        public override string ToString()
        {
            return $"If you do, {OneShotEffect}";
        }
    }
}
