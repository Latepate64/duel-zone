namespace Engine.Abilities
{
    public class SpellAbility : ResolvableAbility
    {
        public SpellAbility(IOneShotEffect effect) : base(effect)
        { }

        public SpellAbility(SpellAbility ability) : base(ability)
        { }

        public override Ability Copy()
        {
            return new SpellAbility(this);
        }

        public override string ToString()
        {
            return UpperCaseFirstCharacter(OneShotEffect.ToString());
        }
    }
}
