namespace DuelMastersModels.Abilities
{
    public class SpellAbility : ResolvableAbility
    {
        public SpellAbility(Resolvable resolvable) : base(resolvable)
        { }

        public SpellAbility(SpellAbility ability) : base(ability)
        { }

        public override Ability Copy()
        {
            return new SpellAbility(this);
        }
    }
}
