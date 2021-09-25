namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class DoubleBreaker : StaticAbility
    {
        internal DoubleBreaker(System.Guid creature) : base(creature) { }

        protected DoubleBreaker(DoubleBreaker ability) : base(ability) { }

        public override Ability Copy()
        {
            return new DoubleBreaker(this);
        }
    }
}

