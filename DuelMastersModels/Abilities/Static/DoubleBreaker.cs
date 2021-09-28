using System;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    public class DoubleBreaker : StaticAbility
    {
        public DoubleBreaker(Guid creature, Guid source) : base(creature, source) { }

        protected DoubleBreaker(DoubleBreaker ability) : base(ability) { }

        public override Ability Copy()
        {
            return new DoubleBreaker(this);
        }
    }
}

