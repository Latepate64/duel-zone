using System;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class Blocker : StaticAbility
    {
        internal Blocker(Guid source, Guid controller) : base(source, controller)
        {
        }

        public Blocker(StaticAbility ability) : base(ability)
        {
        }

        public override StaticAbility Copy()
        {
            return new Blocker(this);
        }
    }
}
