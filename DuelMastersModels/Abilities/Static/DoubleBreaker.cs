using System;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class DoubleBreaker : StaticAbility
    {
        internal DoubleBreaker(Guid creature, Guid source) : base(creature, source) { }

        protected DoubleBreaker(DoubleBreaker ability) : base(ability) { }

        public override StaticAbility Copy()
        {
            return new DoubleBreaker(this);
        }
    }
}

