namespace DuelMastersModels.Abilities.Static
{
    public class DoubleBreaker : StaticAbility
    {
        public DoubleBreaker() : base() { }

        protected DoubleBreaker(DoubleBreaker ability) : base(ability) { }

        public override Ability Copy()
        {
            return new DoubleBreaker(this);
        }
    }
}

