namespace DuelMastersModels.Abilities
{
    public class TapAbility : ActivatedAbility, IAttackable
    {
        public TapAbility(Resolvable resolvable) : base(resolvable)
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
