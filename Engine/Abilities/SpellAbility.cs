namespace Engine.Abilities
{
    public class SpellAbility : ResolvableAbility
    {
        public SpellAbility(OneShotEffect effect) : base(effect)
        { }

        public SpellAbility(SpellAbility ability) : base(ability)
        { }

        public override Ability Copy()
        {
            return new SpellAbility(this);
        }

        public override string ToString()
        {
            var text = OneShotEffect.ToString();
            return char.ToUpper(text[0]) + text[1..];
        }
    }
}
