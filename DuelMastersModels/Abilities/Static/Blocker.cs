namespace DuelMastersModels.Abilities.Static
{
    public class Blocker : StaticAbility
    {
        internal Blocker() : base()
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
