namespace Engine.Abilities
{
    public class TapAbility : ActivatedAbility
    {
        public TapAbility(OneShotEffect effect) : base(effect)
        {
        }

        public TapAbility(ResolvableAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new TapAbility(this);
        }
    }
}
