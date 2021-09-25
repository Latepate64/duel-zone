namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class Blocker : StaticAbility
    {
        internal Blocker(System.Guid source) : base(source)
        {
        }

        public Blocker(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new Blocker(this);
        }
    }
}
