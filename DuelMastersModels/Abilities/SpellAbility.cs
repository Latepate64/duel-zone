namespace DuelMastersModels.Abilities
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
    }
}
