namespace Engine.Abilities
{
    public class SilentSkillAbility : ActivatedAbility
    {
        public SilentSkillAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public SilentSkillAbility(SilentSkillAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new SilentSkillAbility(this);
        }

        public override string ToString()
        {
            return $"Silent skill: {OneShotEffect}";
        }
    }
}
